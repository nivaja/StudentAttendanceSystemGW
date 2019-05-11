using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{

    public class TimeTable
    {
        List<TimeTable> list = new List<TimeTable>();
        public TimeTable() { }
        public List<TimeTable> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TimeTable tt = new TimeTable();
                tt.TimeTableId = Convert.ToInt32(dt.Rows[i]["TimeTableId"]);
                tt.ModuleId = Convert.ToInt32(dt.Rows[i]["ModuleId"]);
                tt.ClassId = Convert.ToInt32(dt.Rows[i]["ClassId"]);
                tt.Day = Convert.ToDateTime(dt.Rows[i]["Day"]);
                tt.StartTime = Convert.ToDateTime(dt.Rows[i]["StartTime"]);
                tt.EndTime = Convert.ToDateTime(dt.Rows[i]["EndTime"]);

                Module module = new Module();
                module.ModuleDescription = dt.Rows[i]["ModuleDescription"].ToString();
                tt.Module = module;

                Class classobject = new Class();
                classobject.ClassDescription = dt.Rows[i]["ClassDescription"].ToString();
                tt.Class = classobject;

                //ClassType classType = new ClassType();
                //classType.ClassTypeDescription = dt.Rows[i]["ClassTypeName"].ToString();
                //tt.ClassType = classType;



                list.Add(tt);
            }
            return list;
        }
        public int TimeTableId { get; set; }


        [Display(Name ="Module")]
        public int ModuleId { get; set; }

        [Display(Name ="Class")]
        public int ClassId { get; set; }
        //public DateTime Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Day { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }


        public List<Attendance> Attendances { get; set; }

        [Display(Name = "Module Class")]
        public string ModuleClass
        {
            get
            {
                return Module.ModuleDescription + " (" + Class.ClassDescription + ")";
            }
        }

    }
}