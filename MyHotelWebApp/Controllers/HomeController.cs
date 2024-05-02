using MyHotelWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelWebApp.Controllers
{
    public class HomeController : Controller
    {
        MyHotelDbContext context = new MyHotelDbContext();
        // GET: Home
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult CustomerHome()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frmc)
        {
            string loginId = frmc["LoginId"];
            string password = frmc["Password"];
            string role = frmc["Role"];

            Login login = context.Logins
                .Where(l => l.LoginId == loginId && l.Password == password && l.Role == role)
                .FirstOrDefault();
            if (login != null)
            {
                Session.Add("LoginId", login.LoginId);
                if (login.Role == "admin")
                {
                    return RedirectToAction("AdminHome");
                   // return Content("Admin Login Success");
                }
                if (login.Role == "Customer")
                {
                    Session.Add("LoginId", login.LoginId);
                    return RedirectToAction("CustomerHome");
                    //return Content("Customer Login Success");
                }
            }
            else
            {
                ViewBag.Message = "Login Credentials Invalid";
                return View("Error");
            }
            return View();
        }

        public ActionResult Register()
        {
            Customer customer = new Customer();
            customer.CustomerID = "Cust" + (new Random()).Next(1000, 99999);
            Session.Add("ID", customer.CustomerID);
            return View();
            //return RedirectToAction("Create","Customer");
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            try
            {
                context.Customers.Add(customer);
                int r = context.SaveChanges();

                if (r > 0)
                {
                    string password = "Psw" + (new Random()).Next(1000, 99999);
                    Login login = new Login()
                    {
                        LoginId = customer.CustomerID,
                        Password = password,
                        Role = "Customer"
                    };
                    context.Logins.Add(login);
                    r = context.SaveChanges();
                    if (r > 0)
                    {
                        ViewBag.Message = "Registration Success";
                        return View("Success");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Registration Failed";
                return View("Error");
            }

            return View();
        }


    }
}