using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Management_System.Models;

namespace Project_Management_System.Controllers
{
    public class AccountController : Controller
    {
        Project_Management_SystemEntitiesDB db = new Project_Management_SystemEntitiesDB();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {

            // Accounts da = new Accounts();

            //List<Account> li = db.Accounts.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)

            {
                if (db.Accounts.Any(x => x.Email == acc.Email))
                {
                    ViewBag.DuplicateMessage = "username already Exist";
                    return View("index", acc);
                }
                else
                {
                    db.Accounts.Add(acc);
                    db.SaveChanges();
                    ViewBag.Successfull = "Registration Successful";
                    return RedirectToAction("index", "Account");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account acc)
        {

            var li = db.Accounts.Where(x => x.Email.Equals(acc.Email) && x.Passwords.Equals(acc.Passwords)).FirstOrDefault();
            if (li != null)
            {


                //  var h = WebSecuruty.getUserId(User.Identity.Name);
                // var y = int.Parse(User.Identity.Name.Split('\\').Last());
                // Account T = db.Accounts.Find(y);

                Session["UserID"] = li.UserID;

                // Session["first_name"] = acc.First_name.ToString();
                Session["Email"] = acc.Email.ToString();

                return RedirectToAction("Index", "Home", new { id = Session["UserID"] });

            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }
    }
}