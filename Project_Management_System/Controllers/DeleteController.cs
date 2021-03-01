using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Models;
namespace Project_Management_System.Controllers
{
    public class DeleteController : Controller
    {
        Project_Management_SystemEntitiesDB db = new Project_Management_SystemEntitiesDB();
        // GET: Delete
        public ActionResult Index(int id)
        {
            var pd = db.Projects.Single(c => c.P_ID == id);
            db.Projects.Remove(pd);
            var bc = db.Project_Details.Single(c => c.P_ID == id);
            int b = id;
            //db.Project_Details.Remove(pd);
           // db.Project_Team.Remove(db.Project_Team.Find(id));
            //db.Project_Stakeholder.Remove(db.Project_Stakeholder.Find(id));
            //db.Cost_Estimation.Remove(db.Cost_Estimation.Find(id));
            
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}