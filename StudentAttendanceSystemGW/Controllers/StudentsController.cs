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
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Students
        public ActionResult Index()
        {
            
            String sql = "SELECT * FROM students";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);


            return View(model);
           

        }

        // GET: Students/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseDescription", null);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", null);
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentsViewModel studentViewModel)
        { 
            if (ModelState.IsValid)
            {
                db.Students.Add(studentViewModel.Student);
                var stdCouSem = new StudentCourseSemester();
                stdCouSem = new StudentCourseSemester()
                {
                    StudentId = studentViewModel.Student.StudentId,
                    CourseId = studentViewModel.CourseId,
                    SemesterId = studentViewModel.SemesterId
                };
                db.StudentCourseSemesters.Add(stdCouSem);
                db.SaveChanges();


              


                return RedirectToAction("Create");
            }

            return View(studentViewModel.Student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();

            
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [Authorize(Roles = "Admin")]

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [Authorize(Roles = "Admin")]
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
           
            String sql = "Delete From Students where StudentID = " + student.StudentId;
            db.Delete(sql);

            return RedirectToAction("Index");
        }
        public ActionResult AttendanceSummary(int id)
        {

            ViewBag.present = db.Attendances.Where(x => x.Status == "P" && x.StudentId == id).Count();

            ViewBag.late = db.Attendances.Where(x => x.Status == "L" && x.StudentId == id).Count();

            ViewBag.absent = db.Attendances.Where(x => x.Status == "A" && x.StudentId == id).Count();

            ViewBag.Attendances = db.Attendances.Where(x => x.StudentId == id).ToList();

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
