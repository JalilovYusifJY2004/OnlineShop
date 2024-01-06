namespace OnlineShop.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Width { get; set; }
        public List<ProductSize>? ProductSizes { get; set; }
    }
}
