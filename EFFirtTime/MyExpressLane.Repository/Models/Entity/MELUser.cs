using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MyExpressLane.Repository.Models
{
    public class MELUser
    {
        public enum Status
        {
            Enabled,
            Disabled
        }
        [Key]
        public int userId { get; set; }
        public string password { get; set; }
        public DateTime lastLogged { get; set; }
        public int status { get; set; }
    }
}