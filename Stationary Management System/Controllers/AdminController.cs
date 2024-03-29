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
            List<Product> products = context.Products.ToList();
            return View(products);
        }




        // GET: AdminController/Details/5
        public IActionResult Detail(int id)
        {
            Product product = context.Products.Find(id);
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




        public ActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductViewModel viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Brand = product.Brand,
                Weight = product.Weight,
                Stock = product.Stock,
                // You may want to load the image path here as well if needed
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Find the existing product
                Product product = context.Products.Find(viewModel.Id);
                if (product == null)
                {
                    return NotFound();
                }

                // Update product properties
                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                product.Brand = viewModel.Brand;
                product.Weight = viewModel.Weight;
                product.Stock = viewModel.Stock;

                // Handle image upload
                if (viewModel.Image != null && viewModel.Image.Length > 0)
                {
                    string uploadsFolder = Path.Combine(web.WebRootPath, "images");

                    // Generate a unique file name for the new image
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetRandomFileName();
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    try
                    {
                        // Copy the new image file to the specified location
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            viewModel.Image.CopyTo(fileStream);
                        }

                        // Delete the old image file if it exists
                        if (!string.IsNullOrEmpty(product.Image))
                        {
                            string oldFilePath = Path.Combine(uploadsFolder, product.Image);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        // Update the image path in the product
                        product.Image = uniqueFileName;
                    }
                    catch (System.IO.IOException ex)
                    {
                        // Handle the exception, log it, or ignore it based on your requirements
                        // For now, let's just log the exception message
                        Console.WriteLine($"An IOException occurred while updating the image: {ex.Message}");

                        // You might want to add a ModelState error here to inform the user about the issue
                    }
                }

                // Save changes
                context.SaveChanges();
                ViewBag.Message = "Record updated";
                return RedirectToAction(nameof(Index)); // Redirect to list action
            }
            // If ModelState is not valid, return the same view with validation errors
            return View(viewModel);
        }


        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the product to delete
                Product product = context.Products.Find(id);

                if (product == null)
                {
                    // Log a message indicating that the product was not found
                    Console.WriteLine($"Product with ID {id} not found.");

                    // If product is not found, return NotFound
                    return NotFound();
                }

                // Store the image path for deletion
                string imagePath = product.Image;

                // Remove the product from the database
                context.Products.Remove(product);
                context.SaveChanges();

                // Delete the associated image file if it exists
                if (!string.IsNullOrEmpty(imagePath))
                {
                    string uploadsFolder = Path.Combine(web.WebRootPath, "images");
                    string filePath = Path.Combine(uploadsFolder, imagePath);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                ViewBag.Message = "Record deleted";
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error deleting product: {ex.Message}");

                // Handle exceptions, log them, or display an error message as needed
                ViewBag.ErrorMessage = $"Error deleting product: {ex.Message}";
            }

            // Redirect to the list action (Index)
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

        public IActionResult ApproveRequest(int requestId)
        {
            // Retrieve the request from the database
            var request = context.Requests.FirstOrDefault(r => r.Id == requestId);

            if (request == null)
            {
                return NotFound();
            }

            // Create a new entry in the ApprovedRequests table
            var approvedRequest = new Approved
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
                RequestedDate = request.Date // Set the Date from the Request table
            };

            // Add the approved request to the approved table
            context.Approveds.Add(approvedRequest);

            // Remove the request from the Requests table
            context.Requests.Remove(request);

            // Save changes to the database
            context.SaveChanges();

            // Redirect back to the candidate list after approval
            return RedirectToAction("CandidateList");
        }

        public IActionResult RejectRequest(int requestId)
        {
            // Retrieve the request from the database
            var request = context.Requests.FirstOrDefault(r => r.Id == requestId);

            if (request == null)
            {
                return NotFound();
            }

            // Create a new entry in the RejectedRequests table
            var rejectedRequest = new Rejected
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
                RequestedDate = request.Date // Set the Date from the Request table
            };

            // Add the rejected request to the rejected table
            context.Rejecteds.Add(rejectedRequest);

            // Remove the request from the Requests table
            context.Requests.Remove(request);

            // Save changes to the database
            context.SaveChanges();

            // Redirect back to the candidate list after rejection
            return RedirectToAction("CandidateList");
        }



        public IActionResult candidate_list()
        {
            var requests = context.Requests
                .Include(r => r.Product)
                .Include(r => r.User)
                .ToList();

            return View(requests);
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
    
