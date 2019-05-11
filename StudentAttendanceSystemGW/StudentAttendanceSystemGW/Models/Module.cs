using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAttendanceSystemGW.Models
{
    public class Module
    {
         List<Module> list = new List<Module>();
         public Module() { }
         public List<Module> List(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Module mod = new Module();
                mod.ModuleId = Convert.ToInt32(dt.Rows[i]["ModuleId"]);
                mod.ModuleDescription = dt.Rows[i]["ModuleDescription"].ToString();
                mod.ModuleCode = dt.Rows[i]["ModuleCode"].ToString();
                mod.CreditHour = Convert.ToInt32(dt.Rows[i]["CreditHour"]);

                list.Add(mod);
            }
            return list;
        }
        [Key]
        public int ModuleId { get; set; }
        public string ModuleDescription { get; set; }
        public string ModuleCode { get; set; }
        public int CreditHour { get; set; }
    }
}