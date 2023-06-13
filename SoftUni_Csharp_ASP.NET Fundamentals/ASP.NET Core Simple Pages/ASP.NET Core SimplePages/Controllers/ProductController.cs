using ASP.NET_Core_SimplePages.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualBasic;
using System.Text;
using System.Text.Json;

namespace ASP.NET_Core_SimplePages.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
       {
        new ProductViewModel()
        {
            Id = 1,
            Name = "Cheese",
            Price = 7.99m
        },
        new ProductViewModel()
        { 
            Id = 2,
            Name = "Ham",
            Price = 5.50m,
        }, 
            new ProductViewModel()
        { 
            Id = 3,
            Name = "Bread",
            Price = 1.80m,
        },
            new ProductViewModel()
        { 
            Id = 4,
            Name = "Tomato",
            Price = 0.80m,
        },
            new ProductViewModel()
        { 
            Id = 5,
            Name = "Lettuse",
            Price = 0.50m,
        }       
       };

        public IActionResult All(string keyword)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var result = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

                return View(result);
            }


            return View(products);
        }


        public IActionResult ById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }


        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }
        public IActionResult AllAsText()
        {
            var asText = "";

            foreach (var product in products)
            {
                asText += $"Product {product.Id}: {product.Name} - ${product.Price}";
                asText += "\r\n";
            }

            return Content(asText);
        }
        public IActionResult AllAsTxtFile()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var product in products)
            {
               sb.AppendLine($"Product {product.Id}: {product.Name} - ${product.Price:f2}");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }

    }
}
