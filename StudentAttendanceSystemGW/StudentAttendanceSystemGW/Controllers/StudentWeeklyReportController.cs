using StudentAttendanceSystemGW.Models;
using StudentAttendanceSystemGW.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAttendanceSystemGW.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class StudentWeeklyReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: StudentWeeklyReport
        public ActionResult Index(DateTime? Date)
        {
            StudentReportVM modelVM = new StudentReportVM();

            if (Date != null)
            {
                DateTime date = (DateTime)Date;
                int year = date.Date.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                DayOfWeek day = date.DayOfWeek;

                CultureInfo cul = CultureInfo.CurrentCulture;
                int weekNo = cul.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                int days = (weekNo - 1) * 7;
                DateTime dt1 = firstDay.AddDays(days);
                DayOfWeek dow = dt1.DayOfWeek;
                DateTime startDateOfWeek = dt1.AddDays(-(int)dow);
                DateTime endDateOfWeek = startDateOfWeek.AddDays(6);

                String sql = "Select s.StudentName, a.Date, a.Status from Students s, Attendances a where s.StudentID = a.StudentID and a.Date " +
                    "between '" + startDateOfWeek + "' and '" + endDateOfWeek + "'";

                var dt = db.List(sql);
                var model = new StudentReportVM().List(dt);
                ViewBag.Report = model;

            }
            else
            {

                ViewBag.Report = "";

            }

            //modelVM.Date = Convert.ToDateTime(Date);

            return View();
        }
    }
}