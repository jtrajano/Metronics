using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EntityFramework6.MVC.Models
{
    public class ProductCategoryGridModel
    {
        public int id { get; set; }
       
        public string name { get; set; }
       
        public int category { get; set; }
    }
}