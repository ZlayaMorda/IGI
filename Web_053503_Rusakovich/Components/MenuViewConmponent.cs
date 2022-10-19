using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_053503_Rusakovich.Models;

namespace Web_053503_Rusakovich.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab 2"},
            new MenuItem{ Controller="Product", Action="Index",Text="Каталог"},
            new MenuItem{ IsPage=true, Area="Admin", Page="/Index", Text="Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            var controller = ViewContext.RouteData.Values["controller"];
            var area = ViewContext.RouteData.Values["area"];

            foreach(var item in _menuItems)
            {
                if((controller?.Equals(item.Controller) ?? false) || (area?.Equals(item.Area) ?? false))
                {
                    item.Active = "active";
                }
            }

            return View(_menuItems);
        }
    }
}
