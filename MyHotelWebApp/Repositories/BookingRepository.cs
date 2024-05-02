using MyHotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        MyHotelDbContext context;
        public BookingRepository(MyHotelDbContext context)
        {
            this.context = context;
        }
        public bool Add(Booking Booking)
        {
            //throw new NotImplementedException();
            //try//HotelId is unique, It may give exception while adding duplicates so to handle it
            //{
                context.Bookings.Add(Booking);//will add new instance of hotel to dbset of hotels collection
            int r = context.SaveChanges();
            if (r > 0)//when add/insert is performed we need to get the status of the record 
            {
                return true;
            }
            else
            {
                return false;
            }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public bool Delete(object id/*, Booking item*/)
        {
            //throw new NotImplementedException();
            int BookingID = (int)id;
            Booking h = context.Bookings.Find(BookingID);
            if (h == null)
            {
                return false;
            }
            context.Bookings.Remove(h);
            int r = context.SaveChanges();
            if (r > 0)//delete is performed we need to get the status of the record 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Booking find(object id)
        {
            //throw new NotImplementedException();
            int BookingID = Convert.ToInt32(id);//to retrieve hotel by hotel id, converting object type to string
            return context.Bookings.Find(BookingID);
        }

        public List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        public bool Update(object id, Booking Booking)
        {
            int BookingID = (int)id;
            Booking h = context.Bookings.Find(BookingID);
            if (h == null)
            {
                return false;
            }
            h.RoomId=Booking.RoomId;
            h.CheckIn=Booking.CheckIn;
            h.CheckOut=Booking.CheckOut;
            h.TotalAmount=Booking.TotalAmount;
            int r = context.SaveChanges();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}