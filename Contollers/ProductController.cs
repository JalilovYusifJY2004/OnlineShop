using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Contollers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            return View();
        }
        public async Task<IActionResult> Detail(int Id)
        {




            if (Id <= 0) return BadRequest();
            Product product = await _context.Products.Include(p => p.Category)
                .Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null) return NotFound();

            List<Product> products = await _context.Products
                .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                .Include(p => p.Category)
                .ToListAsync();

            DetailVm detailVm = new DetailVm
            {
                Product = product,
                RelatedProducts= products,
            };
            return View(detailVm);
        }
    }
}
