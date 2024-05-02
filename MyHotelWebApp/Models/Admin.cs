using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Models
{
    public class Admin
    {
        [Key]
        public string AdminId { get; set; }
        public string AdminName { get; set; }
    }
}