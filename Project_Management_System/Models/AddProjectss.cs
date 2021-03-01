using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Management_System.Models
{
    public class AddProjectss
    {
        public int P_ID { get; set; }
        public string P_Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormatAttribute(DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> Date_Created { get; set; }
        public Nullable<int> UserID { get; set; }

        //
        public int P_Detail_ID { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public string P_Scope { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public string P_Description { get; set; }
        [StringLength(200, MinimumLength = 5)]
        public string P_Objective { get; set; }
        [StringLength(200, MinimumLength = 5)]
        public string P_Goals { get; set; }
        [StringLength(200, MinimumLength = 5)]
        public string P_Oppotunities { get; set; }

        public Nullable<System.DateTime> P_StartDate { get; set; }
        public Nullable<System.DateTime> P_EndDate { get; set; }
        public Nullable<int> P_Duration { get; set; }
       
    }
}