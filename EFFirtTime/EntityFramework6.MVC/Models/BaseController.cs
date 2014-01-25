using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework6.Repository;
using EntityFramework.Patterns;

namespace EntityFramework6.MVC.Models
{
    public class BaseController:Controller
    {
        protected HomeRepository HomeRepo;
        public BaseController(HomeRepository hr)
        {
            HomeRepo = hr;
        }
        #region IController Members

        public void Execute(System.Web.Routing.RequestContext requestContext)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}