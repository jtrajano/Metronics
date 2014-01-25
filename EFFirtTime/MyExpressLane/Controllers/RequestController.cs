using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using MyExpressLane.Web.Repository;
using MyExpressLane.Repository.Models;
using MyExpressLane.Repository.Base;
using GridTools;


namespace MyExpressLane.Controllers
{
    public class RequestController : Controller
    {
        //
        // GET: /Request/
        private RequestRepository req;
        public RequestController()
        {
            req = new RequestRepository();
           
        }
        public ActionResult Index()
        {
            

            return PartialView();
        }
        public ActionResult GridPage() {
            return View();
        }
        public ActionResult AddRequest() {
            TempData["AddRequest"] = "Add Request";
            return PartialView();
        }
        public ActionResult GetGrid(GridPaging paging) 
        {
            try
            {
                var result = req.GetAllRequest().Select(m => new
                {
                    id = m.requestId,
                    wbsno = m.wbsno,
                    summary = m.summary
                }).ToJQGridData(paging, new string[] { "id","wbsno","summary"});
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
                  
          
            
        
        
        //
        // GET: /Request/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Request/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Request/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Request/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Request/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Request/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Request/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
