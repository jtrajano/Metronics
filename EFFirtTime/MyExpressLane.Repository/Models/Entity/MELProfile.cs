using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MyExpressLane.Repository.Models
{
    public class MELProfile
    {
        [Key]
        public int profileId { get; set; }
        public string eid { get; set; }
        public int facilityId { get; set; }
        public string project { get; set; }
        public string shiftId { get; set; }
        public int userId { get; set; }

        [ForeignKey("userId")]
        public MELUser User { get; set; }
    }
}