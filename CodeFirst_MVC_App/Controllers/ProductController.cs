using CodeFirst_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst_MVC_App.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductInfoDbContext _context;

        public ProductController(ProductInfoDbContext context)
        {
            _context = context;
        }

        [Route("AllProducts")]
        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [Route("CreateProduct")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["message"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            TempData["message"] = "Unable to create Product";
            return View(product);
        }
        [Route("ProductDetails/{id}")]
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var product = _context.Products.FirstOrDefault(item => item.ProductId == id);
                if (product != null)
                {
                    return View(product);
                }
                TempData["message"] = "Product Not Found";
                return RedirectToAction("Index");
            }
            TempData["message"] = "Invalid Product Id";
            return RedirectToAction("Index");
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var product = _context.Products.FirstOrDefault(item => item.ProductId == id);
                if (product != null)
                {
                    return View(product);
                }
                TempData["message"] = "Product Not Found";
                return RedirectToAction("Index");
            }
            TempData["message"] = "Invalid Product Id";
            return RedirectToAction("Index");
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                TempData["message"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["message"] = "Unable to update Product";
            return View(product);
        }
        [Route("DeleteProduct/{id}")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id!= null)
            {
                var product = _context.Products.FirstOrDefault(item => item.ProductId == id);
                if(product != null)
                {
                    return View(product);
                }
                TempData["message"] = "Product Not Found";
                return RedirectToAction("Index");
            }
            TempData["message"] = "Invalid Product Id";
            return RedirectToAction("Index");
        }
        [Route("DeleteProduct/{id}")]
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            TempData["message"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
