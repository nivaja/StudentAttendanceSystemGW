using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class Student
    {

        List<Student> list = new List<Student>();
        public Student() { }
        public List<Student> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student studentObj = new Student();
                studentObj.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
                studentObj.ContactNo = dt.Rows[i]["ContactNo"].ToString();
                studentObj.StudentName = dt.Rows[i]["StudentName"].ToString();
                studentObj.Email = dt.Rows[i]["Email"].ToString();
                studentObj.Address = dt.Rows[i]["Address"].ToString();
                studentObj.AdmittedDate = Convert.ToDateTime(dt.Rows[i]["AdmittedDate"]);

                list.Add(studentObj);
            }
            return list;
        }
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public DateTime AdmittedDate { get; set; }
    }
}