using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class Teacher
    {
        List<Teacher> list = new List<Teacher>();
        public Teacher() { }
        public List<Teacher> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Teacher teacherObj = new Teacher();
                teacherObj.TeacherId = Convert.ToInt32(dt.Rows[i]["TeacherID"]);
                teacherObj.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                teacherObj.ContactNo = dt.Rows[i]["ContactNo"].ToString();

                teacherObj.Email = dt.Rows[i]["Email"].ToString();
                teacherObj.TeacherType = (dt.Rows[i]["TeacherType"]).ToString();
                teacherObj.TeachingHours = dt.Rows[i]["TeachingHours"].ToString();


                list.Add(teacherObj);
            }
            return list;
        }

        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string TeachingHours { get; set; }
        public string TeacherType { get; set; }
    }
}