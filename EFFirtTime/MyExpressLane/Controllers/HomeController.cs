using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyExpressLane.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        

        public ActionResult Index()
        {
            //ViewData["Page"] = "DashBoards";


           return View();
        }
        public ActionResult ClientForm() {
           
            return View();
        }
       
    }
}
