using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class StudentCourseSemester
    {
         List<StudentCourseSemester> list = new List<StudentCourseSemester>();
         public StudentCourseSemester() { }
         public List<StudentCourseSemester> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentCourseSemester stuCoSem = new StudentCourseSemester();
                stuCoSem.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
                stuCoSem.CourseId = Convert.ToInt32(dt.Rows[i]["CourseId"]);
                stuCoSem.SemesterId = Convert.ToInt32(dt.Rows[i]["SemesterId"]);

                Student student = new Student();
                student.StudentName = dt.Rows[i]["StudentName"].ToString();
                stuCoSem.Student = student;

                Course course = new Course();
                course.CourseDescription = dt.Rows[i]["CourseDescription"].ToString();
                stuCoSem.Course = course;

                Semester semester = new Semester();
                semester.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                stuCoSem.Semester = semester;

                list.Add(stuCoSem);
            }
            return list;
        }
        [Key,Column(Order=1)]
        public int StudentId { get; set; }
         [Key, Column(Order = 2)]
        public int CourseId { get; set; }
         [Key, Column(Order = 3)]
        public int SemesterId { get; set; }
         public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Semester Semester { get; set; }
    }
}