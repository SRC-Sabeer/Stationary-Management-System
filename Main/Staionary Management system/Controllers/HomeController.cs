using Microsoft.AspNetCore.Identity;
using Staionary_Management_system.Models;
using Staionary_Management_system.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Staionary_Management_system.Controllers
{
	public class HomeController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

		public HomeController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login_Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View("Login_Register", model);
				}
			}
			return View("Login_Register", model);
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					UserName = model.Email,
					Email = model.Email,
					DateCreated = DateTime.Now
				};

				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View("Login_Register", model);
		}
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
