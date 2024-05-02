using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [ForeignKey("Hotel")]
        public string HotelId { get; set; }
        public string Roomtype { get; set; }
        public double RoomPriced { get; set; }
        public string RoomAvailability { get; set; }

        //Ref
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}