using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class Semester
    {
        List<Semester> list = new List<Semester>();
        public Semester() { }
        public List<Semester> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Semester sem = new Semester();
                sem.SemesterId = Convert.ToInt32(dt.Rows[i]["SemesterId"]);
                sem.SemesterName = dt.Rows[i]["SemesterName"].ToString();
                list.Add(sem);
            }
            return list;
        }
        [Key]
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
    }
}