using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Models;
using PagedList.Mvc;
using PagedList;
namespace Project_Management_System.Controllers
{
    public class DisplayProjectController : Controller
    {
        Project_Management_SystemEntitiesDB db = new Project_Management_SystemEntitiesDB();
        // GET: DisplayProject
        public ActionResult Index(string search,int?i)
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Register", "Account");

            }
            else
            {
                int pagelist=0;
                string y = Session["Email"].ToString();
                var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();


                int userID = p.UserID;

                 //List<Project> j = db.Projects.Where(c => c.UserID == id).Select(b=>b.UserID).Distinct().ToList();
                //   
                var query = db.Projects.Where(s => s.UserID == userID).ToList();

                 List<Project> Projects = db.Projects.Where(s => s.UserID == userID).ToList();
                ddd();
                if (pagelist>0) {

                }
                // List<Project> Projec = db.tblUsers.ToList<tblUser>();
                // ViewBag.DuplicateMessage = id;
                //return View(query);
                return View(db.Projects.Where(x=>x.P_Name.StartsWith(search) || search ==null).ToList().ToPagedList(i?? 1,6));

            }

        }

        public void ddd()
        {
            string y = Session["Email"].ToString();
            var p = db.Accounts.Where(c => c.Email == y).FirstOrDefault();

            ViewBag.UserName = p.First_name + " " + p.Last_Name;

        }
    }
}