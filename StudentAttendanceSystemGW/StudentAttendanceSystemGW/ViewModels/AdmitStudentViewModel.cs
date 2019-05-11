using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class AdmitStudentViewModel
    {
        public int CourseID { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }

    }
}