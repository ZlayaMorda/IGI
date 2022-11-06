using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_053503_Rusakovich.Data;
using Web_053503_Rusakovich.Entities;

namespace Web_053503_Rusakovich.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Web_053503_Rusakovich.Data.ApplicationDbContext _context;

        public DetailsModel(Web_053503_Rusakovich.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
