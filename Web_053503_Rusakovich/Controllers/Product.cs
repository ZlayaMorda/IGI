using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_053503_Rusakovich.Models;
using Web_053503_Rusakovich.Data;
using Web_053503_Rusakovich.Extentions;

namespace Web_053503_Rusakovich.Controllers
{
    public class Product : Controller
    {
        List<Entities.Product> ListProducts = new();
        List<Entities.ProductType> ListProductsType = new();
        ApplicationDbContext _context;
        int _pageSize;

        public Product(ApplicationDbContext context)
        {
            _context = context;
            ListProducts = GetProducts();
            ListProductsType = GetTypes();
            _pageSize = 3;
        }

        public List<Entities.Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Entities.ProductType> GetTypes()
        {
            return _context.Types.ToList();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{page}")]
        public ActionResult Index(int? type, int page)
        {
            var productsFiltered = _context.Products.Where(d => !type.HasValue || d.TypeId == type.Value);
            ViewData["Types"] = _context.Types;
            ViewData["CurrentType"] = type ?? 0;
            page = page<=0 ? 1 : page;
            //ViewData["ListProducts"] = new SelectList(ListProducts, "Name", "Description", "Price", "Image");
            var model = ListViewModel<Entities.Product>.GetModel(productsFiltered, page, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }

    }
}
