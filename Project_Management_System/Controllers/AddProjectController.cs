using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Models;
namespace Project_Management_System.Controllers
{
    public class AddProjectController : Controller
    {
        Project_Management_SystemEntitiesDB db = new Project_Management_SystemEntitiesDB();
        // GET: AddProject
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            if (Session["userID"] == null)
            {

                return RedirectToAction("Index", "Account");

            }
            else
            {
                Project ac = new Project();

                

                ddd();
                return View();
            }
        }
        public void ddd()
        {
            string y = Session["Email"].ToString();
            var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();

            ViewBag.UserName = p.First_name + " " + p.Last_Name;

        }

        [HttpPost]
        public ActionResult AddProject(Project addPro)
        {
           

            if (ModelState.IsValid)

            {

                if (db.Projects.Any(x => x.P_Name == addPro.P_Name))
                {

                    ViewBag.DuplicateMessage = "Name already exist";
                    return View("index", addPro);
                }
                else
                {
                    string y = Session["Email"].ToString();
                    var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();


                    int userID = p.UserID;
                    ViewBag.U = (int)userID;

                    // Accounts acc = new Accounts();
                    string proctname = addPro.P_Name.ToString();
                    addPro.Date_Created = DateTime.Now;
                    addPro.UserID = userID;
                    db.Projects.Add(addPro);

                    db.SaveChanges();
                    // ViewBag.DuplicateMessage = y;
                    //  return RedirectToAction("DisplayProjects", "Project", new { id =sesh });
                    return RedirectToAction("AddProjectDetails", "AddProject", new { id = proctname });
                }

            }
            return View();
        }
        [HttpPost]
        public ActionResult AddProjectDetails(Project_Details project_details, string id)
        {
            string y = Session["Email"].ToString();
            var pl = db.Accounts.Where(c => c.Email == y).FirstOrDefault();
            int userID = pl.UserID;

            ViewBag.U = (int)userID;

            //  Accounts acc = new Accounts();

            //projd. = DateTime.Now;

            var p = db.Projects.Where(c => c.P_Name == id).FirstOrDefault();
            // var userid = p.UserID;
            
            project_details.P_ID = p.P_ID;
            db.Project_Details.Add(project_details);

            db.SaveChanges();

            return RedirectToAction("Project_Team_List", "AddProject", new { id = project_details.P_ID });

        }


        public ActionResult AddProjectDetails()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Register", "Account");
            }
            else
            {
                Project_Details project_details = new Project_Details();               
                {
                    // ac.tmm = d.Accounts.ToList<Account>();
                    project_details.Project_list = db.Projects.ToList<Project>();

                }
                ddd();
                return View(project_details);
            }
        }

        public ActionResult Project_Team_List(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Register", "Account");
            }
            else
            {
                var use = db.Accounts.Where(c => c.UserID == id).FirstOrDefault();
                var p = db.Projects.Where(c => c.UserID == id).FirstOrDefault();
                // List<Project> j = db.Projects.Where(c => c.UserID == id).Select(b=>b.UserID).Distinct().ToList();
                //   ViewBag.UserName = use.First_name + " " + use.Last_Name;
                //    var o = p.UserID;
                var query = db.Project_Team.Where(s => s.P_ID == id).ToList();
               //   List<Project> Projects = db.Projects.ToList<Project>();
                ddd();
                // List<Project> Projec = db.tblUsers.ToList<tblUser>();
                ViewBag.projectID = id;
                return View(query);
            }
        }
        public ActionResult Add_Project_Members()
        {
            Project_Team ac = new Project_Team();
            ac.Acccc = db.Accounts.ToList<Account>();


            ddd();
            return View(ac);
        }
        [HttpPost]
        public ActionResult Add_Project_Members(Project_Team project_team, int id)
        {

            project_team.P_ID = id;

            db.Project_Team.Add(project_team);

            db.SaveChanges();
            return RedirectToAction("Project_Team_List", "AddProject", new { id = project_team.P_ID });
            
            // return View();
        }
        [HttpPost]
        public ActionResult Add_Project_Members2(Project_Team project_team, int id)
        {

            project_team.P_ID = id;

            db.Project_Team.Add(project_team);

            db.SaveChanges();
            return RedirectToAction("Project_Team_List", "AddProject", new { id = project_team.P_ID });

            // return View();
        }
        
        public ActionResult Add_Project_Members2()
        {

           
             return View();
        }
        public ActionResult Stakeholders_List(int id)
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Register", "Account");

            }
            else
            {
                
                var query = db.Project_Stakeholder.Where(s => s.P_ID == id).ToList();


                
                ddd();

                ViewBag.projectID = id;
                return View(query);
            }
        }

        public ActionResult Add_Project_Stakeholsers()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add_Project_Stakeholsers(Project_Stakeholder project_stakeholder, int id)
        {


            project_stakeholder.P_ID = id;
            db.Project_Stakeholder.Add(project_stakeholder);

            db.SaveChanges();

            return RedirectToAction("Stakeholders_List", "AddProject", new { id = project_stakeholder.P_ID });

            // return View();
        }

        public ActionResult Project_Cost_List(int id)
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Register", "Account");

            }
            else
            {
                // var use = db.Accounts.Where(c => c.UserID == id).FirstOrDefault();

                // var p = db.Projects.Where(c => c.UserID == id).FirstOrDefault();
                // List<Project> j = db.Projects.Where(c => c.UserID == id).Select(b=>b.UserID).Distinct().ToList();
                //   ViewBag.UserName = use.First_name + " " + use.Last_Name;
                //    var o = p.UserID;
                string y = Session["Email"].ToString();
                var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();


                int userID = p.UserID;

                ViewBag.Userid = userID;
                var query = db.Cost_Estimation.Where(s => s.P_ID == id).ToList();


                //   List<Project> Projects = db.Projects.ToList<Project>();
                ddd();
                // List<Project> Projec = db.tblUsers.ToList<tblUser>();
                ViewBag.projectID = id;
                return View(query);
            }
        }
        public ActionResult ProjectCost()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ProjectCost(Cost_Estimation cost_estimation, int id)
        {
            string y = Session["Email"].ToString();
            var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();


            int userID = p.UserID;

            ViewBag.UserName = userID;
            cost_estimation.P_ID = id;
            db.Cost_Estimation.Add(cost_estimation);

            db.SaveChanges();
            return RedirectToAction("Project_Cost_List", "AddProject", new { id = cost_estimation.P_ID });

            //return RedirectToAction("DisplayProjects", new { id = userID });
        }
    }
}