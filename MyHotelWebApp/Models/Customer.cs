using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Models
{
    public class Customer
    {
        [Key]
        public String CustomerID { get; set; }
        public String CustomerName { get; set; }
        public DateTime CustomerDob {  get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}