using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelWebApp.Models
{
    public class Hotel
    {
        [Key]
        public string HotelID { get; set; }
        public string HotelName { get; set;}
        public string HotelAddress { get; set; }
        public string HotelPhone { get; set; }

        //Collective Navigation Properties
        public virtual ICollection<Room> Rooms { get; set; }

    }
}