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

        public IActionResult Index()
        {
            return View();
        }
    }
}
