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
    public class HomeController : Controller
    {
        Project_Management_SystemEntitiesDB db = new Project_Management_SystemEntitiesDB();

        
        public ActionResult Index(int id, string search, int? i)

        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Index", "Account");

            }
            else
            {
                var p = db.Accounts.Where(c => c.UserID == id).FirstOrDefault();

               // var query = db.Projects.Where(s => s.UserID == id).ToList();

                ViewBag.UserName = p.First_name + " " + p.Last_Name;

                List<Project> Projects = db.Projects.Where(s => s.UserID == id).ToList();


                // List<Project> Projec = db.tblUsers.ToList<tblUser>();
                // ViewBag.DuplicateMessage = id;
                //return View(query);
                return View(db.Projects.Where(s => s.UserID == id ).ToList().ToPagedList(i ?? 1, 6));

                //ddd();

              //  return View(query);

            }
        }
    }
}