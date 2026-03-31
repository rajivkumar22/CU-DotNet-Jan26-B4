using CentralisedPricingEngineMVC.Models;
using CentralisedPricingEngineMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var products = GetProducts();
            bool isValid = _pricingservice.IsValidPromo(promocode);

            var result = products.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                OriginalPrice = p.Price,
                DiscountedPrice = isValid ? _pricingservice.CalculatePrice(p.Price, promocode) : 0
            }).ToList();

            ViewBag.Products = result;
            ViewBag.PromoCode = promocode;
            ViewBag.IsApplied = isValid;

            if (!string.IsNullOrEmpty(promocode) && !isValid)
            {
                ViewBag.Error = "Invalid Promo Code!";
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name) || price <= 0)
            {
                TempData["Error"] = "Invalid product details!";
                return RedirectToAction("Index");
            }

            var products = GetProducts();
            var newProduct = new Product
            {
                Id = products.Any() ? products.Max(p => p.Id) + 1 : 1,
                Name = name,
                Price = price
            };
            products.Add(newProduct);
            SaveProducts(products);

            TempData["Success"] = $"Product '{name}' added successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                var cart = GetCart();
                cart.Add(product);
                SaveCart(cart);
                TempData["Success"] = $"{product.Name} added to cart!";
            }
            return RedirectToAction("Index");
        }

        private List<Product> GetProducts()
        {
            var json = HttpContext.Session.GetString("Products");
            if (string.IsNullOrEmpty(json))
            {
                var defaultProducts = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Price = 1000 },
                    new Product { Id = 2, Name = "Phone", Price = 500 },
                    new Product { Id = 3, Name = "Headphones", Price = 150 },
                    new Product { Id = 4, Name = "Mouse", Price = 50 }
                };
                SaveProducts(defaultProducts);
                return defaultProducts;
            }
            return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
        }

        private void SaveProducts(List<Product> products)
        {
            HttpContext.Session.SetString("Products", JsonConvert.SerializeObject(products));
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
