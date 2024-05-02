using MyHotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        MyHotelDbContext context;
        public RoomRepository(MyHotelDbContext context)
        {
            this.context = context;
        }
        public bool Add(Room Room)
        {
            //throw new NotImplementedException();
            try//HotelId is unique, It may give exception while adding duplicates so to handle it
            {
                context.Rooms.Add(Room);//will add new instance of hotel to dbset of hotels collection
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

        public bool Delete(object id/*, Room Room*/)
        {
            //throw new NotImplementedException();
            int RoomID = (int)id;
            Room R = context.Rooms.Find(RoomID);
            if (R == null)
            {
                return false;
            }
            context.Rooms.Remove(R);
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

        public Room find(object id)
        {
            //throw new NotImplementedException();
           
            if (id != null) 
            {
                int RoomID = (int)id;
                return context.Rooms.Find(RoomID);
            }
           //
            ///to retrieve hotel by hotel id, converting object type to string
            return null;
        }

        public List<Room> GetAll()
        {
            //throw new NotImplementedException();
            return context.Rooms.ToList();
        }

        public bool Update(object id, Room Room)
        {
            //throw new NotImplementedException();
            int RoomID = (int)id;
            Room R = context.Rooms.Find(RoomID);
            if (R == null)
            {
                return false;
            }
            R.RoomPriced=Room.RoomPriced;
            R.RoomAvailability=Room.RoomAvailability;
            R.Roomtype=Room.Roomtype;
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