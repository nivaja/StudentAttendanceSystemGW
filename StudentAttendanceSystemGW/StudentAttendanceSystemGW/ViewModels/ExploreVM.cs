using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class ExploreModulesVM
    {
        List<ExploreModulesVM> list = new List<ExploreModulesVM>();
        public ExploreModulesVM() { }
        public List<ExploreModulesVM> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ExploreModulesVM exploreObj = new ExploreModulesVM();
                exploreObj.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                exploreObj.ModuleDescription = dt.Rows[i]["ModuleDescription"].ToString();
                exploreObj.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                exploreObj.TeacherType = dt.Rows[i]["TeacherType"].ToString();

                list.Add(exploreObj);
            }
            return list;
        }

        //public int TeacherTypeID { get; set; }
        public int CourseID { get; set; }
        public int SemesterID { get; set; }

        public string TeacherName { get; set; }
        public string ModuleDescription { get; set; }
        public string TeacherType { get; set; }
        public string SemesterName { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }
        public virtual IEnumerable<Semester> Semesters { get; set; }
    }



    public class ExploreTeachingHoursVM
    {
        List<ExploreTeachingHoursVM> list = new List<ExploreTeachingHoursVM>();
        public ExploreTeachingHoursVM() { }
        public List<ExploreTeachingHoursVM> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ExploreTeachingHoursVM exploreObj = new ExploreTeachingHoursVM();
                exploreObj.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                exploreObj.Phone = dt.Rows[i]["Phone"].ToString();
                exploreObj.Email = dt.Rows[i]["Email"].ToString();
                //exploreObj.CourseName = dt.Rows[i]["CourseName"].ToString();
                exploreObj.TeachHours = Convert.ToInt32(dt.Rows[i]["TeachHours"]);

                list.Add(exploreObj);
            }
            return list;
        }

        public int SemesterID { get; set; }

        public int TeachHours { get; set; }

        public string TeacherName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CourseName { get; set; }

    }
}