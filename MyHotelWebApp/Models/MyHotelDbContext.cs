using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Models
{
    public class MyHotelDbContext : DbContext
    {
        public MyHotelDbContext() : base("sqlcon")
        {
                
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Login> Logins { get; set; }


    }
}