using StudentAttendanceSystemGW.Models;
using StudentAttendanceSystemGW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAttendanceSystemGW.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class StudentMonthlyReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: StudentMonthlyReport
        
        public ActionResult Index(DateTime? Date)
        {
            StudentReportVM modelVM = new StudentReportVM();

            if (Date != null)
            {
                String sql = "Select s.StudentName, a.Date, a.Status from Students s, Attendances a where s.StudentID = a.StudentID and month(a.Date) = " +
                    " month('" + Date + "') and year(a.Date) =" + " year('" + Date + "')";

                var dt = db.List(sql);
                var model = new StudentReportVM().List(dt);
                ViewBag.Report = model;

            }
            else
            {

                ViewBag.Report = "";

            }

            return View();
        }
    }
}