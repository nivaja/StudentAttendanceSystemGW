using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class Attendance
    {
        public Attendance() { }
        public List<Attendance> List(DataTable dt)
        {
            List<Attendance> list = new List<Attendance>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Attendance attendanceObj = new Attendance();
                attendanceObj.AttendanceId = Convert.ToInt32(dt.Rows[i]["AttendanceId"]);
                attendanceObj.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
                attendanceObj.TimeTableId = Convert.ToInt32(dt.Rows[i]["TimeTableId"]);
                attendanceObj.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
                attendanceObj.EntryTime = Convert.ToDateTime(dt.Rows[i]["EntryTime"]);
                attendanceObj.Status = dt.Rows[i]["Status"].ToString();


                Student studentObj = new Student();
                studentObj.StudentName = dt.Rows[i]["StudentName"].ToString();
                attendanceObj.Student = studentObj;

                TimeTable routineObj = new TimeTable();
                routineObj.ModuleId = Convert.ToInt32(dt.Rows[i]["ModuleId"]);
                attendanceObj.TimeTable = routineObj;

                Module ModuleDescription = new Module();
                ModuleDescription.ModuleDescription = Convert.ToString(dt.Rows[i]["ModuleDescription"]);
                routineObj.Module = ModuleDescription;
                list.Add(attendanceObj);
            }
            return list;
        }
        [Key]
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int TimeTableId { get; set; }
        public DateTime Date { get; set; }
        public DateTime EntryTime { get; set; }
        public string Status { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("TimeTableId")]
        public virtual TimeTable TimeTable { get; set; }
        
        
    }
}