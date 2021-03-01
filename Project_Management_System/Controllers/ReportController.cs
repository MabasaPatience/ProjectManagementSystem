using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Models;
namespace Project_Management_System.Controllers
{
    public class ReportController : Controller
    {
        Project_Management_SystemEntitiesDB db = new Project_Management_SystemEntitiesDB();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report(int id)
        {

            Project_Forms acc = new Project_Forms();
            // Project pr = new Project();

            // List<Project> k = db.Projects.ToList();

            acc.Project_Project_Forms = db.Projects.Single(p => p.P_ID == id);
            acc.ProjectDetails_Project_Forms = db.Project_Details.Single(d => d.P_ID == id);

            //List<Project_Team> Projectsli = db.Project_Team.Where(s => s.P_ID == id).ToList();

            //acc.Project_Team_Project_Forms = db.Project_Team.Single(l => l.P_ID == id);
            //acc.ProjectStakeholder_Project_Forms = db.Project_Stakeholder.Single(k => k.P_ID == id);
            //acc.ProjectCost_Project_Forms = db.Cost_Estimation.Single(m => m.P_ID == id);

            //var pf  = db.Projects.Single(p => p.ProjectID == id);
            ddd();
            return View(acc);

        }

        public ActionResult ReportTeam(int id)
        {
            var p = db.Accounts.Where(c => c.UserID == id).FirstOrDefault();

            var query = db.Project_Team.Where(s => s.P_ID == id).ToList();

            ViewBag.ProjectID = id;

            ddd();
            return View(query);
        }
        public ActionResult ReportStakeholders(int id)
        {
            var p = db.Accounts.Where(c => c.UserID == id).FirstOrDefault();

            var query = db.Project_Stakeholder.Where(s => s.P_ID == id).ToList();

            ViewBag.ProjectID = id;

            ddd();
            return View(query);
        }
        public ActionResult ReportResources(int id)
        {
            var p = db.Accounts.Where(c => c.UserID == id).FirstOrDefault();

            var query = db.Cost_Estimation.Where(s => s.P_ID == id).ToList();

            ViewBag.ProjectID = id;

            ddd();
            return View(query);
        }
        public void ddd()
        {
            string y = Session["Email"].ToString();
            var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();

            
            ViewBag.UserName = p.First_name + " " + p.Last_Name;
            ViewBag.UserID = p.UserID ;
        }
    }
}