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
    public class IndexModel : PageModel
    {
        private readonly Web_053503_Rusakovich.Data.ApplicationDbContext _context;

        public IndexModel(Web_053503_Rusakovich.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
