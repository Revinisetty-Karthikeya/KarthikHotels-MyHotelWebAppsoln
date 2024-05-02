using MyHotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Repositories
{
    public class HotelRepository : IRepository<Hotel>
    {
        MyHotelDbContext context;
        public HotelRepository(MyHotelDbContext context)
        {
            this.context = context;
        }

        public bool Add(Hotel Hotel)
        {
            //throw new NotImplementedException();
            try//HotelId is unique, It may give exception while adding duplicates so to handle it
            {
                context.Hotels.Add(Hotel);//will add new instance of hotel to dbset of hotels collection
                int r = context.SaveChanges();
                if (r > 0)//when add/insert is performed we need to get the status of the record 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public bool Delete(object id)
        {
            //throw new NotImplementedException();
            string HotelID = (string)id;
            Hotel h = context.Hotels.Find(HotelID);
            if (h == null)
            {
                return false;
            }
            context.Hotels.Remove(h);
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

        public Hotel find(object id)//find or get by
        {

            string HotelID = (string)id;//to retrieve hotel by hotel id, converting object type to string
            return context.Hotels.Find(HotelID);
        }

        public List<Hotel> GetAll()
        {
            return context.Hotels.ToList();//to get all the hotels in to a list
        }

        public bool Update(object id, Hotel hotel)
        {
            //throw new NotImplementedException();
            string HotelID = (string)id;
            Hotel h = context.Hotels.Find(HotelID);
            if (h == null)
            {
                return false;
            }
            h.HotelPhone = hotel.HotelPhone;
            h.HotelAddress = hotel.HotelAddress;
            h.HotelName = hotel.HotelName;
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