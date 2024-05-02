using MyHotelWebApp.Models;
using MyHotelWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelWebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        //public ActionResult Index()
        //{
        //    return View();
        //}

        CustomerRepository CustomerBO = new CustomerRepository(new Models.MyHotelDbContext());

        public ActionResult Index()
        {
            List<Customer> customers = CustomerBO.GetAll();
            return View(customers);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(string id)
        {
            Customer customer = CustomerBO.find(id);
            return View(customer);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(/*FormCollection collection*/Customer model)
        {
            /*try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {*/
                    bool b = CustomerBO.Add(model);
                    if (b)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error");
                    }
            return View(model);
            /*}
            else
            {
                return View(model);
            }

        }
        catch
        {
            return View("Error");
        }*/
    }

            // GET: Hotel/Edit/5
            public ActionResult Edit(string id)
        {
            Customer customer = CustomerBO.find(id);
            return View(customer);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer/*nt id, FormCollection collection*/)
        {

            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                string CustomerID = customer.CustomerID;
                bool b = CustomerBO.Update(CustomerID, customer);
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
                return View(customer);
            }
            //return RedirectToAction("Index");

        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(string id)
        {
            bool b = CustomerBO.Delete(id);
            if (b)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}