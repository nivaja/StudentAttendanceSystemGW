
using StudentAttendanceSystemGW.ViewModels;
using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAttendanceSystemGW.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ExploreModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExploreModules
        public ActionResult Index(int? ModuleId, int? SemesterId)
        {
           
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleDescription");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName");

            String sql = "SELECT Distinct (t.TeacherID), t.teacherName,t.TeacherType, s.semesterName, c.ModuleDescription FROM teachers t, TeacherModules tc, " +
                "Modules c, CourseSemesterModules fsc, semesters s where  t.teacherId = tc.teacherId and tc.ModuleId = c.ModuleId and c.ModuleId = fsc.courseId and fsc.semesterid = s.semesterid and c.ModuleId = '"+  ModuleId +"' and s.semesterid = '"+ SemesterId  +"' order by t.teacherName";
            var dt = db.List(sql);
            var model = new ExploreModulesVM().List(dt);


            ViewBag.Explore = model;

            return View();
        }
    }
}