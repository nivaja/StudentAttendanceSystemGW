using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class CourseSemesterModule
    { 
       List<CourseSemesterModule> list = new List<CourseSemesterModule>();
        public CourseSemesterModule() { }
        public List<CourseSemesterModule> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CourseSemesterModule CouSemMo = new CourseSemesterModule();
                CouSemMo.CourseId = Convert.ToInt32(dt.Rows[i]["CourseId"]);
                CouSemMo.SemesterId = Convert.ToInt32(dt.Rows[i]["SemesterId"]);
                CouSemMo.ModuleId = Convert.ToInt32(dt.Rows[i]["ModuleId"]);


                Course course = new Course();
                course.CourseDescription = dt.Rows[i]["CourseDescription"].ToString();
                CouSemMo.Course = course;

                Semester sem = new Semester();
                sem.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                CouSemMo.Semester = sem;

                Module mod = new Module();
                mod.ModuleDescription = dt.Rows[i]["ModuleDescription"].ToString();
                CouSemMo.Module = mod;

                list.Add(CouSemMo);
            }
            return list;
        }
        
        [Key,Column(Order=1)]
        public int CourseId { get; set; }

        [Key, Column(Order = 2)]
        public int SemesterId { get; set; }

        [Key, Column(Order = 3)]
        public int ModuleId { get; set; }


        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }
    }
}