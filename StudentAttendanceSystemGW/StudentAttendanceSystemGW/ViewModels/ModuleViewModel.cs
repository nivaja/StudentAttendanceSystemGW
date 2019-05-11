﻿using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class ModuleViewModel
    {

        public int CourseId { get; set; }
        public int SemesterId { get; set; }
        public virtual Module Module { get; set; }
    }
}