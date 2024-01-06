using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Areas.OnlineShopAdmin.Controllers
{
    [Area("OnlineShopAdmin")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
