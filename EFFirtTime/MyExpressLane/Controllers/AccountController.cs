using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MyExpressLane.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        
        [HttpPost]
        public EmptyResult Login(Account account) {
            
            FormsAuthentication.RedirectFromLoginPage(account.username, true);
            return null;
            
        }

        
        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
            
        }
        [HttpPost]
        public ActionResult ResetPassword() {
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Signup() {
            return RedirectToAction("Login");
        }

    }
    public class Account
    {
        public string password { get; set; }
        public string username { get; set; }
    }
}
