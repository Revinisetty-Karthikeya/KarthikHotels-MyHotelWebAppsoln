using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingId { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("Room")]

        public int RoomId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }
        public string TotalAmount { get; set; }

    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Room Room { get; set; }


    }
}