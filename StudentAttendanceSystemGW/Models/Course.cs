using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class Course
    {
        List<Course> list = new List<Course>();
        public Course() { }
        public List<Course> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Course mod = new Course();
                mod.CourseId = Convert.ToInt32(dt.Rows[i]["CourseId"]);
                mod.CourseDescription = dt.Rows[i]["CourseDescription"].ToString();
                

                list.Add(mod);
            }
            return list;
        }
        [Key]
        public int CourseId { get; set; }
        public string CourseDescription { get; set; }

    }
}