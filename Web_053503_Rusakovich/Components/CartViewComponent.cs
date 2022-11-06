using Microsoft.AspNetCore.Mvc;
using Web_053503_Rusakovich.Models;

namespace Web_053503_Rusakovich.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
