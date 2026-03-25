using CentralisedPricingEngineMVC.Services;
using Microsoft.AspNetCore.Mvc;

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
            decimal cartTotal = 1500;

            if (!string.IsNullOrEmpty(promocode))
            {

                decimal finalTotal = _pricingservice.CalculatePrice(cartTotal, promocode);

                ViewBag.CartTotal = cartTotal;
                ViewBag.FinalTotal = finalTotal;
                ViewBag.PromoCode = promocode;
                ViewBag.Applied = true;
            }
            else
            {
                ViewBag.Applied = false;
                if (!string.IsNullOrEmpty(promocode))
                {
                    ViewBag.Error = "Invalid Promo Code!";
                }
            }

            return View();
        }
    }
}
