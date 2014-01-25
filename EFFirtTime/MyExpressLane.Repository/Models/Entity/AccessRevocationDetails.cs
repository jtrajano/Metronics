using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MyExpressLane.Repository.Models
{
    public class AccessRevocationDetails
    {
        public int accessrevocationDetailsId { get; set; }
        public int accessrevocationId { get; set; }
        public string eid { get; set; }
        public string domain { get; set; }
        public string domainId { get; set; }
        public string project { get; set; }
        public string projectmanager { get; set; }

        

    }
}