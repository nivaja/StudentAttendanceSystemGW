using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentAttendanceSystemGW.Models;
using StudentAttendanceSystemGW.ViewModels;



namespace StudentAttendanceSystemGW.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Modules
        public ActionResult Index()
        {
            String sql = "SELECT * FROM Modules";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Module().List(dt);

            return View(model);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

    

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseDescription");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName");
  
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModuleViewModel MVM)
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseDescription");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName");
            if (ModelState.IsValid)
            {
                //String sql = "Insert into Courses (CourseName, CourseCode, CreditHour) values ('" + course.CourseName + "', '" + course.CourseCode + "', '" + course.CreditHour + "')";

                //db.Create(sql);

               // db.Courses.Add(Vmodel.Course);

                var CouSemMod = new CourseSemesterModule();
                CouSemMod = new CourseSemesterModule()
                {
                    CourseId = MVM.CourseId,
                    SemesterId = MVM.SemesterId,
                    ModuleId = MVM.Module.ModuleId
                };
                db.Modules.Add(MVM.Module);
                db.CourseSemesterModules.Add(CouSemMod);


                db.SaveChanges();


                return RedirectToAction("Create");
            }

            return null;
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
              //  db.Entry(model.Module).State = EntityState.Modified;
                db.SaveChanges();

                //String sql = "Update Courses set CourseName = " + "'" + course.CourseName + "'" + ", CourseCode = " + "'" + course.CourseCode + "'" + ", CreditHour = " + "'" + course.CreditHour + "'" + " where CourseID = " + course.CourseID;
                //db.Edit(sql);
                return RedirectToAction("Create");
            }
            return View(model.Module);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module mod = db.Modules.Find(id);
            String sql = "Delete From Modules where ModuleId = " + mod.ModuleId;
            db.Delete(sql);
            return RedirectToAction("Index");
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
