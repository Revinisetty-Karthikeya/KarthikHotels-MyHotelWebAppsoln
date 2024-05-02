using MyHotelWebApp.Models;
using MyHotelWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace MyHotelWebApp.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public static MyHotelDbContext Context = new Models.MyHotelDbContext();
        BookingRepository BookingBO = new BookingRepository(Context);

        public ActionResult Index()
        {
            List<Booking> bookings = BookingBO.GetAll();



            return View(bookings);
        }

        public ActionResult CustomerBookingIndex()
        {
            List<Booking> bookings = BookingBO.GetAll().Where(m => m.CustomerId == (string)Session["LoginId"]).ToList();



            return View(bookings);
        }
        public ActionResult CustomerIndex(string CustomerId)
        {
            List<Booking> bookings = BookingBO.GetAll().Where(b => b.CustomerId == CustomerId).ToList();
            



            return View(bookings);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            Booking booking = BookingBO.find(id);
            return View(booking);
        }
        public ActionResult CustomerBookingDetails(int id)
        {
            Booking booking = BookingBO.find(id);
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            Booking booking = new Booking();
            MyHotelDbContext context = new MyHotelDbContext();

            ViewBag.RoomIds = new SelectList(Context.Rooms, "RoomID", "RoomID");
            ViewBag.CustomerIds = new SelectList(Context.Customers, "CustomerID", "CustomerID");



            //ViewBag.BookingIds = new SelectList(Context.Bookings, "BookingID", "BookingID");
            return View(booking);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(/*FormCollection collection*/Booking model)
        {
            //try
            //{
            // TODO: Add insert logic here

            if (ModelState.IsValid)
            {
                
                bool b = BookingBO.Add(model);
                if (b)
                {
                    return RedirectToAction("Index");
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

        public ActionResult CustomerBookingCreate(int id)
        {
            Booking booking = new Booking();
            booking.RoomId = id;
            MyHotelDbContext context = new MyHotelDbContext();
            


            return View(booking);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult CustomerBookingCreate(Booking model)
        {
            //try
            //{
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                int a = new Random().Next(1, 1000);
                Booking booking = Context.Bookings.Find(a);
                while (booking != null)
                {
                    a = new Random().Next(1, 1000);
                    booking = Context.Bookings.Find(a);

                }
                model.BookingId = a;
                model.CustomerId = (string)Session["LoginId"];
                MyHotelDbContext context = new MyHotelDbContext();
                Room room =  context.Rooms.Find(model.RoomId);
                string HotelId = room.HotelId;
                model.TotalAmount = room.RoomPriced.ToString();
                bool b = BookingBO.Add(model);
                if (b)
                {
                    return RedirectToAction("CustomerBookingIndex", "Booking");
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


        //GET: Hotel/Edit/5
        public ActionResult Edit(string id)
        {
            Booking booking = BookingBO.find(id);
            return View(booking);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(Booking booking/*nt id, FormCollection collection*/)
        {

            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                int BookingId = booking.BookingId;
                bool b = BookingBO.Update(BookingId, booking);
                if (b)
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
                return View(booking);
            }
            //return RedirectToAction("Index");

        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            bool b = BookingBO.Delete(id);
            if (b)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public ActionResult CustomerBookingDelete(int id)
        {
            bool b = BookingBO.Delete(id);
            if (b)
            {
                return RedirectToAction("CustomerBookingIndex");
            }
            return View("Error");
        }
    }
}