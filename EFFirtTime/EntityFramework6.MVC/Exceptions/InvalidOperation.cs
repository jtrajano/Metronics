using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
namespace EntityFramework6.MVC.Exceptions
{
    public class InvalidOperation:Exception
    {
        public InvalidOperation(string message):base (message)
        {

        }
 
    }
}