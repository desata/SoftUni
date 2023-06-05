using ASP.NET_Core_Introduction.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Introduction.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
        { 
            new ProductViewModel()
            { 
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.30
            },
        };
    }

    public IActionResult All()
    {

        return View();
    }
}
