using MyHotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotelWebApp.Repositories
{
    internal interface IRepository<T> where T : class
    {
        List<T> GetAll();

        bool Add(T item);

        bool Update(object id,T item);
        bool Delete(object id/*,T item*/);
        T find(object id);



    }
}
