using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class ModuleVM
    {
        List<ModuleVM> list = new List<ModuleVM>();
        public ModuleVM() { }
        public List<ModuleVM> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModuleVM mod = new ModuleVM();
                mod.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                mod.CourseName = dt.Rows[i]["CourseName"].ToString();
                mod.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                mod.TypeName = dt.Rows[i]["TypeName"].ToString();

                list.Add(mod);
            }
            return list;
        }


        public int CourseID { get; set; }
        public int SemesterID { get; set; }

        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string TypeName { get; set; }
        public string SemesterName { get; set; }

        public virtual IEnumerable<Module> Modules { get; set; }
        public virtual IEnumerable<Semester> Semesters { get; set; }
    }
}