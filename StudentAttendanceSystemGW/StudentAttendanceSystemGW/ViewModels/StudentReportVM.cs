    using StudentAttendanceSystemGW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.ViewModels
{
    public class StudentReportVM
    {

        List<StudentReportVM> list = new List<StudentReportVM>();
        public StudentReportVM() { }
        public List<StudentReportVM> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentReportVM report = new StudentReportVM();
                report.StudentName = dt.Rows[i]["StudentName"].ToString();
                report.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
                report.Status = dt.Rows[i]["Status"].ToString();

                list.Add(report);
            }
            return list;
        }



        public string StudentName { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Status { get; set; }



        public int StudentID { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public IEnumerable<Student> Student { get; set; }

    }



}