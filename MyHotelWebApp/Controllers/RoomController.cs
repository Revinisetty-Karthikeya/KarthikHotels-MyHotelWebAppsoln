using MyHotelWebApp.Models;
using MyHotelWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelWebApp.Controllers
{
    public class RoomController : Controller
    {
        //// GET: Room
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // GET: Hotel
        public static MyHotelDbContext Context  = new Models.MyHotelDbContext();
        RoomRepository RoomBO = new RoomRepository(Context);
        [HttpGet]
        public ActionResult Index(string id)
        {
            List<Room> Rooms = RoomBO.GetAll().Where(r=>r.HotelId==id).ToList();
              
            return View(Rooms);
        }
        public ActionResult CustomerRoomIndex(string id)
        {
            List<Room> Rooms = RoomBO.GetAll().Where(r => r.HotelId == id).ToList();



            return View(Rooms);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            Room room = RoomBO.find(id);
            return View(room);
        }

        public ActionResult CustomerRoomDetails(int id)
        {
            Room room = RoomBO.find(id);
            return View(room);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            Room room = new Room();
            MyHotelDbContext context = new MyHotelDbContext();
            ViewBag.HotelIds = new SelectList(Context.Hotels, "HotelID", "HotelID");
            return View(room);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(/*FormCollection collection*/Room model)
        {
            //try
            //{
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    bool b = RoomBO.Add(model);
                    if (b)
                    {
                        return RedirectToAction("Index", new {id = model.HotelId });
                    }
                    else
                    {
                        return View("Error");
                        //return View();
                    }
                }
                else
                {
                    return View(model);
                }

            //}
            //catch
            //{
            //    return View("Error");
            //    //return View();
            //}
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            Room room = RoomBO.find(id);
            return View(room);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(Room room/*nt id, FormCollection collection*/)
        {

            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                int roomId = room.RoomId;
                bool b = RoomBO.Update(roomId, room);
                if (b)
                {
                     return RedirectToAction("Index", "Room", new {id=room.HotelId});
                }
                else
                {
                    return View("Error");
                }

            }
            else
            {
                return View(room);
            }
            //return RedirectToAction("Index");

        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            bool b = RoomBO.Delete(id);
            if (b)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}