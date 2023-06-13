namespace ASP.NET_Core_SimplePages.Models.Product
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
