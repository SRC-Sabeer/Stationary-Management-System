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
            var products = await context.Products.ToListAsync();
            return View(products);
        }


        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description,Price1,Price2,Price3,Warranty,Application,PlaceOfOrigin,Brand,Size,Function,PackageWeight")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Add(product);
        //        await context.SaveChangesAsync();
        //        return RedirectToAction(nameof(List));
        //    }
        //    return View(product);
        //}

        //[HttpPost]
        //public IActionResult Create(ProductViewModel pro)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string filename = pro.Image.FileName;
        //        var filePath = Path.Combine(web.WebRootPath, "images");
        //        var path = Path.Combine(filePath, filename);
        //        pro.Image.CopyTo(new FileStream(path, FileMode.Create));
        //        //path = wwwroot/images/abc.jpg/
        //        Product i = new Product()
        //        {
        //            Name = pro.Name,
        //            Description = pro.Description,
        //            Price1 = pro.Price1,
        //            Price2 = pro.Price2,
        //            Price3 = pro.Price3,
        //            Warranty = pro.Warranty,
        //            Application = pro.Application,
        //            PlaceOfOrigin = pro.PlaceOfOrigin,
        //            Brand = pro.Brand,
        //            Size = pro.Size,
        //            Function = pro.Function,
        //            PackageWeight = pro.PackageWeight,
        //            Image = filename,
        //        };
        //        context.Products.Add(i);
        //        context.SaveChanges();
        //        ViewBag.message = "Record inserted";
        //    }
        //    else
        //    {
        //        ViewBag.message = "Record not";
        //    }
        //    return View();
        //}


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
                    Price1 = viewModel.Price1,
                    Price2 = viewModel.Price2,
                    Price3 = viewModel.Price3,
                    Warranty = viewModel.Warranty,
                    Application = viewModel.Application,
                    PlaceOfOrigin = viewModel.PlaceOfOrigin,
                    Brand = viewModel.Brand,
                    Size = viewModel.Size,
                    Function = viewModel.Function,
                    PackageWeight = viewModel.PackageWeight,
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



        // GET: AdminController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price1,Price2,Price3,Warranty,Application,PlaceOfOrigin,Brand,Size,Function,PackageWeight")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(product);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(product);
        }




        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await context.Products.FindAsync(id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool ProductExists(int id)
        {            return context.Products.Any(e => e.Id == id);
        }
   



// GET: AdminController
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
    
