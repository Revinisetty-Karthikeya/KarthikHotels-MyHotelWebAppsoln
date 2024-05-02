using MyHotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelWebApp.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        MyHotelDbContext context;
        public CustomerRepository(MyHotelDbContext context)
        {
            this.context = context;
        }
        public bool Add(Customer Customer)
        {
            //throw new NotImplementedException();
            try//HotelId is unique, It may give exception while adding duplicates so to handle it
            {
                context.Customers.Add(Customer);//will add new instance of hotel to dbset of hotels collection
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

        public bool Delete(object id/*, Customer item*/)
        {
            //throw new NotImplementedException();
            string CustomerID = (string)id;
            Customer h = context.Customers.Find(CustomerID);
            if (h == null)
            {
                return false;
            }
            context.Customers.Remove(h);
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

        public Customer find(object id)
        {
            //throw new NotImplementedException();
            string CustomerID = (string)id;//to retrieve hotel by hotel id, converting object type to string
            return context.Customers.Find(CustomerID);
        }

        public List<Customer> GetAll()
        {
            //throw new NotImplementedException();
            return context.Customers.ToList();//to get all the hotels in to a list

        }

        public bool Update(object id, Customer Customer)
        {
            //throw new NotImplementedException();
            string CustomerID = (string)id;
            Customer h = context.Customers.Find(CustomerID);
            if (h == null)
            {
                return false;
            }
            h.CustomerPhone = Customer.CustomerPhone;
            h.CustomerDob = Customer.CustomerDob;
            h.CustomerName = Customer.CustomerName;
            h.CustomerEmail = Customer.CustomerEmail;

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