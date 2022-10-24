using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_053503_Rusakovich.Data;
using Web_053503_Rusakovich.Entities;

namespace Web_053503_Rusakovich.Controllers
{
    public class Product : Controller
    {
        List<Entities.Product> ListProducts = new();
        List<Entities.ProductType> ListProductsType = new();
        ApplicationDbContext _context;

        public Product(ApplicationDbContext context)
        {
            _context = context;
            ListProducts = GetProducts();
            ListProductsType = GetTypes();
        }

        public List<Entities.Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Entities.ProductType> GetTypes()
        {
            return _context.Types.ToList();
        }

        public ActionResult Index()
        {
            //ViewData["ListProducts"] = new SelectList(ListProducts, "Name", "Description", "Price", "Image");
            return View(ListProducts);
        }

    }
}
