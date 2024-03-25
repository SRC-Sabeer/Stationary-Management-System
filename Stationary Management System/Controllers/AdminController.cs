using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stationary_Management_System.Models;
using Stationary_Management_System.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Stationary_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly SMSContext context;
        private readonly IWebHostEnvironment web;

        public AdminController(SMSContext context , IWebHostEnvironment web)
        {
            this.context = context;
            this.web = web;
        }


        public ActionResult list()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> List()
        {
            var products = context.Products.ToList();
            return View(products);
        }


        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }



        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (viewModel.Image != null)
                {
                    string uploadsFolder = Path.Combine(web.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Product product = new Product
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                  Price = viewModel.Price,
                  
                 
                 
                    Brand = viewModel.Brand,
                 
                    Weight = viewModel.Weight,
                    Stock = viewModel.Stock,
                    Image = uniqueFileName
                };

                context.Products.Add(product);
                context.SaveChanges();
                ViewBag.Message = "Record inserted";
            }
            else
            {
                ViewBag.Message = "Record not inserted";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
                return View();
            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = context.Products.Find(viewModel.Id);
                if (product == null)
                {
                    return NotFound();
                }
                // Update product properties with ViewModel data
                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                product.Brand = viewModel.Brand;
                product.Weight = viewModel.Weight;
                product.Stock = viewModel.Stock;

                context.SaveChanges();
                ViewBag.Message = "Record updated";
            }
            else
            {
                ViewBag.Message = "Record not updated";
            }
            return View(viewModel);
        }



        public ActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public ActionResult Index()
        {
            return View();
        }






       
        public IActionResult auth_confirm_mail()
    {
        return View();
    }

    public IActionResult auth_email_verification()
    {
        return View();
    }

    public IActionResult auth_lockscreen()
    {
        return View();
    }

    public IActionResult auth_login()
    {
        return View();
    }

    public IActionResult auth_register()
    {
        return View();
    }

    public IActionResult auth_recoverpw()
    {
        return View();
    }

    public IActionResult candidate_list()
    {
        return View();
    }

    public IActionResult candidate_overview()
    {
        return View();
    }

    public IActionResult contact_list()
    {
        return View();
    }

    public IActionResult contact_profile()
    {
        return View();
    }

    public IActionResult ecommerce_add_product()
    {
        return View();
    }

    public IActionResult ecommerce_cart()
    {
        return View();
    }

    public IActionResult ecommerce_checkout()
    {
        return View();
    }

    public IActionResult ecommerce_customer()
    {
        return View();
    }

    public IActionResult ecommerce_order()
    {
        return View();
    }

    public IActionResult ecommerce_product_detail()
    {
        return View();
    }

    public IActionResult ecommerce_products()
    {
        return View();
    }

    public IActionResult ecommerce_shops()
    {
        return View();
    }

    public IActionResult email_inbox()
    {
        return View();
    }
    public IActionResult email_read()
    {
        return View();
    }

    public IActionResult email_template_alert()
    {
        return View();
    }

    public IActionResult email_template_basic()
    {
        return View();
    }

    public IActionResult email_template_billing()
    {
        return View();
    }

    public IActionResult invoices_detail()
    {
        return View();
    }

    public IActionResult invoices_list()
    {
        return View();
    }

    public IActionResult tables_datatables()
    {
        return View();
    }

    
    }
}
    
