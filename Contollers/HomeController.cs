using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Contollers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> slides =await _context.Slides.OrderBy(s=>s.Order).Take(3).ToListAsync();
          
            List<Product> products = await _context.Products.Include(p=>p.ProductImages.Where(pi => pi.IsPrimary!=null)).ToListAsync();
           List<Category> categories= await _context.Categories.ToListAsync();
            HomeVm vm = new HomeVm
            {
                Slides = slides,
                Products = products,
                Categories = categories
            };
            
            return View(vm);
        }
    }
}
