using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace EntityFramework6.MVC.ActionFilters
{
    public class CustomExceptionActionAttribute:ActionFilterAttribute,IExceptionFilter
    {

        #region IExceptionFilter Members

        public void OnException(ExceptionContext filterContext)
        {

            if (filterContext.Exception.GetType().Name == "InvalidOperation")
                filterContext.Result =
                    new RedirectResult("~/Test");
            //throw new NotImplementedException();
        }

        #endregion
    }
    
}