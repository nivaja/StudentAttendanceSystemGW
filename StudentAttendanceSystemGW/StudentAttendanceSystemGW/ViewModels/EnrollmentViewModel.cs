using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class EnrollmentViewModel { 
        public int ModuleId { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
    
    }
}