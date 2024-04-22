using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext data;

        public BookController(LibraryDbContext context)
        {
            data = context;
        }
        public async Task<IActionResult> All()
        {
            var book = await data.Books
                .Select(b => new BookInfoViewModel(
                    b.Id,
                    b.ImageUrl,
                    b.Title,
                    b.Author,
                    b.Rating,
                    b.Category.Name                    
                    ))
                .ToListAsync();

            return View();
        }
    }
}
