using MyHotelWebApp.Models;
using MyHotelWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelWebApp.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        HotelRepository HotelBO = new HotelRepository(new Models.MyHotelDbContext());

        public ActionResult Index()
        {
            List<Hotel> hotels = HotelBO.GetAll();
            return View(hotels);
        }
        public ActionResult CustomerIndex()
        {
            List<Hotel> hotels = HotelBO.GetAll();
            return View(hotels);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(string id)
        {
            Hotel hotel=HotelBO.find(id);
            return View(hotel);
        }

        public ActionResult CustomerHotelDetails(string id)
        {
            Hotel hotel = HotelBO.find(id);
            return View(hotel);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            Hotel hotel = new Hotel();
            hotel.HotelID = (new Random()).Next(1000, 99999).ToString();
            return View(hotel);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(Hotel model)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                   bool b= HotelBO.Add(model);
                    if(b)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    return View(model);
                }

            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(string id)
        {
            Hotel hotel = HotelBO.find(id);
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(Hotel hotel/*nt id, FormCollection collection*/)
        {
            
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    string HotelId = hotel.HotelID;
                    bool b=HotelBO.Update(HotelId, hotel);
                    if(b)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error");
                    }

                }
                else
                {
                    return View(hotel);
                }
                //return RedirectToAction("Index");
            
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(string id)
        {
            bool b = HotelBO.Delete(id);
            if(b)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        // POST: Hotel/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
