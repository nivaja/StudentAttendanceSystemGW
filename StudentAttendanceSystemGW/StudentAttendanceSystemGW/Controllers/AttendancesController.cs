using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentAttendanceSystemGW.Models;

namespace StudentAttendanceSystemGW.Controllers
{
    [Authorize(Roles = "Admin, Teacher, User")]
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendances
        public ActionResult Index(int? TimeTableId)
        {
            
            var Day = db.TimeTables.AsEnumerable().Where(x => x.Day.Equals(Convert.ToString(DateTime.Now.DayOfWeek)));
            ViewBag.TimeTableId = new SelectList(Day, "TimeTableId", "ModuleClass");
            String sql = "select * from students std" +
                " join StudentCourseSemesters sfs on std.StudentID = sfs.StudentID" +
                " join Semesters sem on sem.SemesterID = sfs.SemesterID" +
                " join CourseSemesterModules fsc on fsc.SemesterID = sem.SemesterID" +
                " join Courses f on f.CourseId = fsc.CourseId" +
                " and f.CourseId = sfs.CourseId" +
                " join Modules c on c.ModuleId = fsc.ModuleId" +
                " join TimeTables r on r.ModuleId = c.ModuleId" +
                " and TimetableID = '" + TimeTableId + "'";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);

            //modelVM.Students = model;

            ViewBag.Students = model;
            ViewBag.TimeTableId = new SelectList(db.TimeTables, "TimeTableId", "ModuleClass");

            return View();
        }

        [HttpPost]
        public ActionResult Index(Attendance attendance)
        {


            var startTime = db.Attendances.Where(x => x.TimeTableId == attendance.TimeTableId).Select(x => x.TimeTable.StartTime).FirstOrDefault();
            var entryTime = (attendance.EntryTime).ToString("HH:mm tt");
            if (attendance.EntryTime.ToString() == "1/1/0001 12:00:00 AM")
            {
                attendance.EntryTime = Convert.ToDateTime("1/1/2022 12:00:00 PM");
            }
            var st = startTime.ToString("HH:mm tt");
            var diff = (DateTime.Parse(entryTime) - DateTime.Parse(st)).TotalMinutes;
            if (attendance.EntryTime.ToString() == "1/1/2022 12:00:00 PM")
            {
                attendance.Status = "A";
            }

            else if (diff > 5)
            {
                attendance.Status = "L";
            }
            else if (diff <= 5)
            {
                attendance.Status = "P";
            }


            //    attendance.Status = "A";
            ViewBag.TimeTableId = new SelectList(db.TimeTables, "TimeTableId", "ModuleClass");

            db.Attendances.Add(attendance);
            db.SaveChanges();



            return View();
        }

     

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}
