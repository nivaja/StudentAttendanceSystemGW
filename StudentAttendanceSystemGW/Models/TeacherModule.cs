using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class TeacherModule
    {
        List<TeacherModule> list = new List<TeacherModule>();
        public TeacherModule() { }
        public List<TeacherModule> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TeacherModule teacherMod = new TeacherModule();
                teacherMod.TeacherId = Convert.ToInt32(dt.Rows[i]["TeacherId"]);
                teacherMod.ModuleId = Convert.ToInt32(dt.Rows[i]["ModuleId"]);


                Teacher teacher = new Teacher();
                teacher.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                teacherMod.Teacher = teacher;


                Module mod = new Module();
                mod.ModuleDescription = dt.Rows[i]["ModuleDescription"].ToString();
                teacherMod.Module = mod;

                list.Add(teacherMod);
            }
            return list;
        }
         [Key,Column(Order=1)]
        public int TeacherId { get; set; }
        [Key, Column(Order = 2)]
        public int ModuleId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Module Module { get; set; }
    }
}