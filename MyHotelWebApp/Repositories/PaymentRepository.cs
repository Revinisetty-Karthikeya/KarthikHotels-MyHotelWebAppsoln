using MyHotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Repositories
{
    public class PaymentRepository : IRepository<Payment>
    {
        MyHotelDbContext context;
        public PaymentRepository(MyHotelDbContext context)
        {
            this.context = context;
        }


        public List<Payment> customerPayment(string customerId)
        {
            List<Booking> bookings  = context.Bookings.Where(a =>  a.CustomerId == customerId).ToList();
            List<Payment> Allpayments = context.Payments.ToList();
            var payments = new List<Payment>();
            foreach(var b in bookings)
            {
                foreach(var p in Allpayments)
                {
                    if(p.BookingId == b.BookingId)
                    {
                        payments.Add(p);
                    }
                }
            }
            return payments;
        }


        public double TotalAmountPaid(int bookingId)

        {
            Booking booking = context.Bookings.Find(bookingId);
            int roomNo = booking.RoomId;
            Room room = context.Rooms.Find(roomNo);
            double price = room.RoomPriced;


            DateTime checkin = booking.CheckIn;
            DateTime checkout = booking.CheckOut;
            int days = (int)(checkout - checkin).TotalDays;

            double total = price* days;
            return total;

        }




        public bool Add(Payment payment)
        {
            //throw new NotImplementedException();
            /*try//HotelId is unique, It may give exception while adding duplicates so to handle it
            {*/
                context.Payments.Add(payment);//will add new instance of hotel to dbset of hotels collection
                int r = context.SaveChanges();
                if (r > 0)//when add/insert is performed we need to get the status of the record 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            /*}
            catch (Exception ex)
            {
                throw ex;
            }*/
        }

        public bool Delete(object id/*, Payment item*/)
        {
            //throw new NotImplementedException();
            int PaymentID = Convert.ToInt32(id);
            Payment h = context.Payments.Find(PaymentID);
            if (h == null)
            {
                return false;
            }
            context.Payments.Remove(h);
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

        public Payment find(object id)
        {
            //throw new NotImplementedException();
            int PaymentId = Convert.ToInt32(id);
            return context.Payments.Find(PaymentId);
        }

        public List<Payment> GetAll()
        {
            //throw new NotImplementedException();
            return context.Payments.ToList();
        }

        public List<Payment> paymentByBookId(int bookingId)
        {
            List<Payment> payments = context.Payments.Where(a => a.BookingId == bookingId).ToList();

            return payments;
        }

        public bool Update(object id, Payment Payment)
        {
            //throw new NotImplementedException();
            int PaymentID = (int)id;
            Payment h = context.Payments.Find(PaymentID);
            if (h == null)
            {
                return false;
            }
            h.PaymentDate = Payment.PaymentDate;
            h.AmountPaid = Payment.AmountPaid;
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