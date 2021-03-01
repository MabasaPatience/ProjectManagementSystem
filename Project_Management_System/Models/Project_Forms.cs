using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Management_System.Models
{
    public class Project_Forms
    {
        public Account account_Project_Forms { get; set; }

        public Project Project_Project_Forms{ get; set; }

        public Project_Team Project_Team_Project_Forms { get; set; }

        public Cost_Estimation ProjectCost_Project_Forms { get; set; }

        public Project_Details ProjectDetails_Project_Forms { get; set; }

        public Project_Stakeholder ProjectStakeholder_Project_Forms { get; set; }
        //  public String Email { get; set; }
        //public  IEnumerable<Account> St { get; set; }
        //public IEnumerable<Project> pjjj  { get; set; }
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project_Team> ProjecMembers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cost_Estimation> ProjectCosts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project_Details> ProjectDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project_Stakeholder> Stakeholders { get; set; }



        [NotMapped]
        public List<Account> AccList { get; set; }
        [NotMapped]

        public List<Project_Team> projectMemberList { get; set; }
        //[NotMapped]

        //public List<Project> projectlist { get; set; }
        //[NotMapped]

        //public List<ProjectDetail> projectDetailsList { get; set; }
        //[NotMapped]

        //public List<ProjectCost> projectCostlist { get; set; }

        //[NotMapped]

        public List<Project_Stakeholder> StackholdersList { get; set; }


    }
}