using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MyExpressLane.Repository.Models
{
    public class MELRequest
    {
        [Key]
        public int requestId { get; set; }
        public DateTime date_request { get; set; }
        public string summary { get; set; }
        public string wbsno { get; set; }
        public string requestTypeId { get; set; }
        public string loggedby { get; set; }
        public string eid { get; set; }


    }
}