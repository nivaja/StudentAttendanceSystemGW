using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class TimeTableVM
    {
        public virtual Module Module { get; set; }
        public virtual Class Class { get; set; }
        public virtual TimeTable TimeTable { get; set; }  

    }
}