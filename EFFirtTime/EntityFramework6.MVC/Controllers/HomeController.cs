using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NUnit.Framework;
using EntityFramework6.Repository;
using EntityFramework.Patterns;
using EntityFramework6.MVC.Models;
using GridTools;
using System.Text;
using EntityFramework6.MVC.Exceptions;
using EntityFramework6.MVC.ActionFilters;
namespace EntityFramework6.MVC.Controllers
{
    [CustomExceptionAction]
    public class HomeController : BaseController
    {
        public HomeController()
            : base(new HomeRepository())
        {
            
                
        }
      

        
        public ActionResult Index()
        {
            throw new InvalidOperation("Testing global exception handling");
            StringBuilder s = new StringBuilder(" :");

            IEnumerable<ProductCategory> cat =
                HomeRepo.CatRepo.GetAll()
                .Select(m =>
                    new ProductCategory
                    {
                        Id = m.Id,
                        Name = m.Name

                    });
            foreach (var item in cat)
            {
                s.Append(";" +item.Id + ":" + item.Name);
            }
            ViewBag.Categories = s.ToString();

            return View();
            

        }
        public ActionResult About()
        {
            IEnumerable<Product> lst = HomeRepo.ProductRepo.GetAll();
            IEnumerable<ProductCategory> cat = HomeRepo.CatRepo.GetAll();
            return View();
        }
        public ActionResult Grid(GridPaging paging) 
        {


            JQGridData jq = HomeRepo.ProductRepo.GetAll().Select(s => new
            {
                id = s.Id,
                Name = s.Name,
                Category = s.ProductCategory.Name
            }).AsQueryable().ToJQGridData(paging, new[] { "id", "Name", "Category" });
            return Json(jq, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Grid(ProductCategoryGridModel p) {
            //if(!ModelState.IsValid)
            //    return 

            HomeRepo.ProductRepo.Insert(new Product
            {
                Name = p.name,
                ProductCategoryId = p.category
            });
            HomeRepo.Commit();
            return Json("success", JsonRequestBehavior.AllowGet);
        }

            
    }
}
