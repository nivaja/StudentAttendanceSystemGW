using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class AttendanceVM
    {
        public List<Attendance> Attendances { get; set; }
        public ICollection<Student> Students { get; set; }
       

    }
}