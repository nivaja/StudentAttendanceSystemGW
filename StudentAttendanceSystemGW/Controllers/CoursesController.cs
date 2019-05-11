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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            String sql = "SELECT CourseId,CourseDescription FROM courses";
            //db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);

            return View(model);
        }

        

        // GET: Faculties/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course cou)
        {
            
            if (ModelState.IsValid)
            {


                db.Courses.Add(cou);

                var CouSemMod = new CourseSemesterModule();
           
                db.SaveChanges();

                return RedirectToAction("Create");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseDescription", null);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", null);
            return View();
        }

        // GET: Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course faculty = db.Courses.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course cou)
        {
            if (ModelState.IsValid)
            {
                String sql = "Update Courses set CourseDescription = '" + cou.CourseDescription + "' where CourseId = " + cou.CourseId;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(cou);
        }

        // GET: Faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course cou = db.Courses.Find(id);
            String sql = "Delete From Courses where CourseId = " + cou.CourseId;
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
