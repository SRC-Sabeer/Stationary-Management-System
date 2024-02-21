using Microsoft.AspNetCore.Mvc;
using Staionary_Management_system.Models;
using System.Diagnostics;

namespace Staionary_Management_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            return View();
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

        public IActionResult Login_Register()
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

        

        public IActionResult Privacy()
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
