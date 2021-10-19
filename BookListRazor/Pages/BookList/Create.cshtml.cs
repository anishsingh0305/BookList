using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _DB;
        public CreateModel(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet()
        {
            // Book = await _DB.
            return;
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _DB.Book.AddAsync(Book);
                await _DB.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
