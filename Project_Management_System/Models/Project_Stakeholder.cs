//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Project_Stakeholder
    {
        public int S_ID { get; set; }
        public string S_Fullname { get; set; }
        public string S_Email { get; set; }
        [ForeignKey("P_ID")]
        public Nullable<int> P_ID { get; set; }
    
        public virtual Project Project { get; set; }
        public List<Account> Acccc { get; set; }
    }
}
