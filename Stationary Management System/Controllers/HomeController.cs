﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stationary_Management_System.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace Stationary_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly SMSContext context;

        public HomeController(SMSContext context)
        {
            this.context = context;
        }

        private IActionResult RedirectToLogin()
        {
            return RedirectToAction("Login", "Home");
        }
        private bool IsUserLoggedIn()
        {
            return HttpContext.Session.GetString("UserId") != null;
        }

        // Redirect to login page if user is not logged in
    

        // Action method for pages that require authentication
        private IActionResult ProtectedAction()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToLogin();
            }
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await context.Users.SingleOrDefaultAsync(u => u.Email == model.email && u.Password == model.password);
                if (user != null)
                {
                    // User authenticated successfully, you can redirect to a dashboard or any other protected page
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("Acc_Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already registered
                if (context.Users.Any(u => u.Email == model.email))
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View(model);
                }

                // You can add more validation and customization as needed before saving the user
                var user = new User
                {
                    Firstname = model.firstname,
                    Lastname = model.lastname,
                    Email = model.email,
                    Password = model.password
                };
                context.Users.Add(user);
                await context.SaveChangesAsync();

                // You can redirect to login page or any other appropriate page
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Acc_Dashboard()
        {
            return ProtectedAction();
        }

        public IActionResult Acc_Address()
        {
            return View();
        }

        public IActionResult Acc_Edit()
        {
            return View();
        }

        public IActionResult Acc_Order()
        {
            return View();
        }

        public IActionResult Acc_Wishlist()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Coming_soon()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

      


  

      




        public IActionResult LookBook()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Reset_Password()
        {
            return View();
        }

        public IActionResult Shop_Cart()
        {
            return View();
        }

        public IActionResult Shop_Checkout()
        {
            return View();
        }

        public IActionResult Shop_Order_Complete()
        {
            return View();
        }

        public IActionResult Shop_Order_Tracking()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Store_Location()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
