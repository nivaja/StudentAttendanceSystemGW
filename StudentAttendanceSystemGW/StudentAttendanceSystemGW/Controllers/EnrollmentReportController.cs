
using StudentAttendanceSystemGW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StudentAttendanceSystemGW.Models;


namespace StudentAttendanceSystemGW.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class EnrollmentReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnrollmentReport
        public ActionResult Index(int? ModuleId)
        {
            AdmitStudentViewModel modelVM = new AdmitStudentViewModel();
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleDescription");
            
            String sql = "SELECT Distinct (s.StudentID), s.StudentName, s.email, s.contactNo, s.address, s.AdmittedDate FROM students s, studentcoursesemesters sfs, Courses f, CourseSemesterModules fsc, Modules c where s.studentId = sfs.studentId and f.courseid = sfs.courseid and fsc.courseid = f.courseid and fsc.courseid = c.ModuleId and c.ModuleId = '" + ModuleId +"' order by AdmittedDate";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);

            //return View(model);
            modelVM.Students = model;

            return View(modelVM);
        }
    }
}