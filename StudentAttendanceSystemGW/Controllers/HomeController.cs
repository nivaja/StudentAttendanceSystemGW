
using StudentAttendanceSystemGW.Models;
using StudentAttendanceSystemGW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace StudentAttendanceSystemGW.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.user = user;
            ViewBag.Students = db.Students.Count();
            ViewBag.Modules = db.Modules.Count();
            ViewBag.Teachers = db.Teachers.Count();
            ViewBag.Classes = db.Classes.Count();
            return View();
        }

        public JsonResult getAttendanceReport()
        {
            List<int> list = new List<int>();
            var a = db.Attendances.Where(ad => ad.Status == "A").Count();
      
            var p = db.Attendances.Where(ad => ad.Status == "P").Count();
            var l = db.Attendances.Where(ad => ad.Status == "L").Count();
            list.Add(a); list.Add(p); list.Add(l);
           
            return new JsonResult() { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

     
    }

    
}