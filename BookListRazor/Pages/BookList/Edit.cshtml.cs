using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _DB;
        public EditModel(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _DB.Book.FindAsync(id);

        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookDetails = await _DB.Book.FindAsync(Book.Id);
                BookDetails.Name = Book.Name;
                BookDetails.Author = Book.Author;
                BookDetails.ISBN = Book.ISBN;

                await _DB.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("Index");
            }
           
        }
    }
}
