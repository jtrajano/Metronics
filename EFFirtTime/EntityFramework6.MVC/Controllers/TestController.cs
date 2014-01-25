using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework6.Repository;
namespace EntityFramework6.MVC.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Product p) 
        {
            if(!ModelState.IsValid)
                return RedirectToAction("/");
            return View();
        }

    }
}
