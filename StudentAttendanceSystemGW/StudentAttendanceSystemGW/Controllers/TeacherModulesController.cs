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
    [Authorize(Roles = "Admin, User")]
    public class TeacherModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherModules
        public ActionResult Index()
        {
            String sql = "SELECT * FROM teachermodules tm, modules mo, teachers t where tm.moduleid  = mo.moduleid and tm.teacherid = t.teacherid";
            db.List(sql);
            var dt = db.List(sql);
            var model = new TeacherModule().List(dt);

            return View(model);
        }

        // GET: TeacherCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModule teacherModule = db.TeacherModules.Find(id);
            if (teacherModule == null)
            {
                return HttpNotFound();
            }
            return View(teacherModule);
        }

        // GET: TeacherCourses/Create
        public ActionResult Create()
        {
            ViewBag.ModuleId = new SelectList(db.Modules, "moduleId", "ModuleDescription");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: TeacherCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherModule teachermodule)
        {
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleDescription", teachermodule.ModuleId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", teachermodule.TeacherId);
            if (ModelState.IsValid)
            {
                db.TeacherModules.Add(teachermodule);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

           
            return View(teachermodule);
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
