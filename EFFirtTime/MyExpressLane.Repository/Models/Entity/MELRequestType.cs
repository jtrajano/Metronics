using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MyExpressLane.Repository.Models
{
    public class MELRequestType
    {
        [Key]
        public int requestTypeId { get; set; }
        public string description { get; set; }


    }
}