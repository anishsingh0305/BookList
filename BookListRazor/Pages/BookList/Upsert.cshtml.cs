using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _DB;
        public UpsertModel(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book(); 
            if(id == null)
            {
                return Page();
            }
            
            Book = await _DB.Book.FindAsync(id);
            if(Book == null)
            {
                return NotFound();
            }
            return Page();

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Book.Id == 0)
                {
                    _DB.Book.Add(Book);
                }
                else
                {
                    _DB.Book.Update(Book);
                }

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
