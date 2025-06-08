using Microsoft.AspNetCore.Mvc.RazorPages;
using BooksApplication.Generators;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using BooksApplication.Models;

namespace BooksApplication.Pages
{
    public class BooksModel : PageModel
    {
        private readonly Generator _generator;

        public BooksModel()
        {
            _generator = new Generator();
        }

        [BindProperty(SupportsGet = true)]
        public string Locale { get; set; } = "ja";

        [BindProperty(SupportsGet = true)]
        public int Seed { get; set; } = 42;

        [BindProperty(SupportsGet = true)]
        public double Likes { get; set; } = 3.7;

        [BindProperty(SupportsGet = true)]
        public double Review { get; set; } = 4.2;

        [BindProperty(SupportsGet = true)]
        public int Pages { get; set; } = 0;

        public List<Book> Books { get; set; } = new List<Book>();

        public void OnGet()
        {
            Books = _generator.GenerateBooks(Locale, Seed, Pages, Likes, Review);
        }

        public IActionResult OnGetLoadMoreAsync(int page)
        {
            var anotherBooks = _generator.GenerateBooks(Locale, Seed, page, Likes, Review, 10);
            return new JsonResult(anotherBooks);
        }
    } 
}