using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassDescription { get; set; }
        public string ClassType { get; set; }

    }
}