using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MyExpressLane.Repository.Models
{
    public class ServerRoomAccess
    {
        [Key]
        public int sraId { get; set; }
        public string accessType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int facilityId { get; set; }
        public int requestId { get; set; }

        [ForeignKey("requestId")]
        public MELRequest Request { get; set; }
    }
}