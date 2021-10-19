using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _DB;
        public IndexModel(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _DB.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _DB.Book.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            _DB.Book.Remove(book);
            await _DB.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
