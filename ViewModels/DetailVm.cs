using OnlineShop.Models;

namespace OnlineShop.ViewModels
{
    public class DetailVm
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
    }
}
