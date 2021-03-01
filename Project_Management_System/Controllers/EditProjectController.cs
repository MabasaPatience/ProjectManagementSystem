using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Models;
namespace Project_Management_System.Controllers
{
    public class EditProjectController : Controller
    {
        Project_Management_SystemEntitiesDB db = new Project_Management_SystemEntitiesDB();
        // GET: EditProject
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult EditProject(int id)
        {
            var item = db.Projects.Where(x => x.P_ID == id).First();
            if (item == null)
            {
                return HttpNotFound();
            }

            ddd();
            return View(item);

        }
        [HttpPost]
        public ActionResult EditProject()
        {

            ddd();
            return View();

        }
        public void ddd()
        {
            string y = Session["Email"].ToString();
            var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();

            ViewBag.UserName = p.First_name + " " + p.Last_Name;

        }
        [HttpGet]
        public ActionResult EditProjectDetails(int id)
        {
            var item = db.Project_Details.Where(x => x.P_ID == id).First();
            if (item == null)
            {
                return HttpNotFound();
            }

            ddd();
            return View(item);

        }
        [HttpPost]
        public ActionResult EditProjectDetails()
        {

            ddd();
            return View();

        }
        public ActionResult EditProjectTeam(int id)
        {
            Project_Team ac = new Project_Team();
            // var item = db.ProjecMembers.Where(x => x.ProjectID == id).First();
            if (id != 0)
            {
                ac = db.Project_Team.Where(x => x.P_ID == id).First();
                ac.Acccc = db.Accounts.ToList<Account>();
                return View(ac);
            }

            ViewBag.Email = new SelectList(db.Accounts, "Email", "Email");
            // ac.Acccc = db.Accounts.ToList<Account>();



            ddd();
            return View(ac);

        }
        [HttpPost]
        public ActionResult EditProjectTeam(Project_Team project_team)
        {
            ddd();
            return View();

        }
    }
}