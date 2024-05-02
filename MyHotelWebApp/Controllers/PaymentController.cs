using MyHotelWebApp.Models;
using MyHotelWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelWebApp.Controllers
{
    public class PaymentController : Controller
    {

        public static MyHotelDbContext Context = new Models.MyHotelDbContext();
        PaymentRepository PaymentBO = new PaymentRepository(Context);


        public ActionResult Index()
        {
            List<Payment> payments = PaymentBO.GetAll();
            return View(payments);
        }
        public ActionResult CustomerPaymentIndex()
        {
            string custId = (string)Session.Contents["LoginId"];
            List<Payment> payments = PaymentBO.customerPayment(custId);

            return View(payments);
        }

        public ActionResult CustomerPayments(int bookingId)
        {
            List<Payment> payments = PaymentBO.paymentByBookId(bookingId);
            return View(payments);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(string id)
        {
            Payment payment = PaymentBO.find(id);
            return View(payment);
        }
        public ActionResult CustomerPaymentDetails(string id)
        {
            Payment payment = PaymentBO.find(id);
            return View(payment);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            Payment payment = new Payment();
            MyHotelDbContext context = new MyHotelDbContext();
            ViewBag.BookingIds = new SelectList(Context.Bookings, "BookingId", "BookingId");


            return View(payment);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(/*FormCollection collection*/Payment model)
        {
             // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    bool b = PaymentBO.Add(model);
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
                    return View(model);
                }

            
        }

        [HttpGet]
        public ActionResult PaymentBookingId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PaymentBookingId(FormCollection frmc)
        {
            string Id = frmc["bookingId"];
            int bookId = int.Parse(Id);
            return RedirectToAction("CustomerCreate", new { bookingId =  bookId});
        }


        public ActionResult CustomerCreate(int bookingId)
        {
            Payment payment = new Payment();

            MyHotelDbContext context = new MyHotelDbContext();

            double totalamount = PaymentBO.TotalAmountPaid(bookingId);
            ViewBag.BookingIds = new SelectList(Context.Bookings, "BookingId", "BookingId");
            ViewBag.TotalAmount=totalamount;


            payment.BookingId= bookingId;
            payment.AmountPaid = totalamount.ToString();


            return View(payment);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult CustomerCreate(/*FormCollection collection*/Payment model)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                bool b = PaymentBO.Add(model);
                if (b)
                {

                    return RedirectToAction("CustomerPaymentIndex");
                    //return View("Success");
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




        // GET: Hotel/Edit/5
        public ActionResult Edit(string id)
        {
            Payment payments = PaymentBO.find(id);
            return View(payments);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(Payment payment/*nt id, FormCollection collection*/)
        {

            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                int PaymentId = payment.PaymentId;
                bool b = PaymentBO.Update(PaymentId, payment);
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
                return View(payment);
            }
            //return RedirectToAction("Index");

        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(string id)
        {
            bool b = PaymentBO.Delete(id);
            if (b)
            {
                return RedirectToAction("CustomerPaymentIndex");
            }
            return View("Error");
        }
    }
}