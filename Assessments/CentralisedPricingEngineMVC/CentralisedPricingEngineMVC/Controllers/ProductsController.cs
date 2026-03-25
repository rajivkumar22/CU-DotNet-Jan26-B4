using CentralisedPricingEngineMVC.Models;
using CentralisedPricingEngineMVC.Services;
using Microsoft.AspNetCore.Mvc;



namespace CentralisedPricingEngineMVC.Controllers
    {
        public class ProductsController : Controller
        {
            private readonly IPricingService _pricingservice;
            public ProductsController(IPricingService pricingservice)
            {
                _pricingservice = pricingservice;
            }

            public IActionResult Index(string promocode)
            {
                var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1000 },
                new Product { Id = 2, Name = "Phone", Price = 500 }
            };
            bool isValid = _pricingservice.IsValidPromo(promocode);

            var result = products.Select(p => new
            {
                Name = p.Name,
                OriginalPrice = p.Price,
                DiscountedPrice = isValid
                    ? _pricingservice.CalculatePrice(p.Price, promocode)
                    : 0
            }).ToList();

            ViewBag.Products = result;
            ViewBag.PromoCode = promocode;
            ViewBag.IsApplied = isValid;

            if (!string.IsNullOrEmpty(promocode) && !isValid)
            {
                ViewBag.Error = "Invalid Promo Code!";
            }

            return View();
            //foreach(var ch in products)
            //{

            //   decimal discountedprice = _pricingservice.CalculatePrice(Price, promocode);

            //}

            //  decimal discountedprice = _pricingservice.CalculatePrice(Price, promocode);

            //ViewBag.Discount = discountedprice;
            //return View();
        }
        }
    }


    //decimal Price = 1000;
    //        string promocode = "WINTER25";
    //        decimal discountedprice = _pricingservice.CalculatePrice(Price, promocode);
    //        ViewBag.Original = Price;
    //        ViewBag.Discount = discountedprice;
    //        return View();
        
    

