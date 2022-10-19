using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_053503_Rusakovich.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Web_053503_Rusakovich.Controllers
{
    public class Home : Controller
    {
        private readonly List<ListDemo> _listDemo;

        public Home()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue = 1, ListItemText = "Item_1" },
                new ListDemo{ ListItemValue = 2, ListItemText = "Item_2" },
                new ListDemo{ ListItemValue = 3, ListItemText = "Item_3" }
            };

        }

        // GET: Home
        public ActionResult Index()
        {
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
            ViewData["Lab"] = "Лабораторная работа № 2";
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public class ListDemo 
    {
        public int ListItemValue { get; set; }

        public string ListItemText { get; set; }
    }

}
