using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace MyExpressLane.Repository.Models
{
    public class AccessRevocation
    {
        
        public int accessrevocationId { get; set; }
        public int requestId { get; set; }
        public DateTime lastDay { get; set; }
        public DateTime effectiveDay{ get; set; }
        
        //[ForeignKey("requestId")]
        
        public MELRequest Request { get; set; }
        
        //[ForeignKey("accessrevocationId")]
        public ICollection<AccessRevocationDetails> AccessRevocationDetails { get; set; }


    }
}