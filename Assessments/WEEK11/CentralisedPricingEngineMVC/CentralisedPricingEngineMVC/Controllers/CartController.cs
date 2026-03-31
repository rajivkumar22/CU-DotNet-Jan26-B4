using CentralisedPricingEngineMVC.Models;
using CentralisedPricingEngineMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CentralisedPricingEngineMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IPricingService _pricingservice;

        public CartController(IPricingService pricingservice)
        {
            _pricingservice = pricingservice;
        }

        public IActionResult Index(string promocode)
        {
            var cart = GetCart();
            decimal cartTotal = cart.Sum(p => p.Price);

            ViewBag.CartItems = cart;
            ViewBag.CartTotal = cartTotal;

            if (!string.IsNullOrEmpty(promocode) && _pricingservice.IsValidPromo(promocode))
            {
                decimal finalTotal = _pricingservice.CalculatePrice(cartTotal, promocode);
                ViewBag.FinalTotal = finalTotal;
                ViewBag.PromoCode = promocode;
                ViewBag.Applied = true;
                ViewBag.Discount = cartTotal - finalTotal;
            }
            else if (!string.IsNullOrEmpty(promocode))
            {
                ViewBag.Error = "Invalid Promo Code!";
                ViewBag.Applied = false;
            }
            else
            {
                ViewBag.Applied = false;
            }

            return View();
        }

        [HttpPost]
        public IActionResult RemoveItem(int index)
        {
            var cart = GetCart();
            if (index >= 0 && index < cart.Count)
            {
                cart.RemoveAt(index);
                SaveCart(cart);
                TempData["Success"] = "Item removed from cart!";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            TempData["Success"] = "Cart cleared!";
            return RedirectToAction("Index");
        }

        private List<Product> GetCart()
        {
            var json = HttpContext.Session.GetString("Cart");
            return string.IsNullOrEmpty(json) ? new List<Product>() : JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
        }

        private void SaveCart(List<Product> cart)
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }
    }
}

