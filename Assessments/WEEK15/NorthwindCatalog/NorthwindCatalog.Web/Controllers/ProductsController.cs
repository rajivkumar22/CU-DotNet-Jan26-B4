using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.Models;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;

        public ProductsController(IConfiguration config)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(config["ApiBaseUrl"])
            };
        }

        public async Task<IActionResult> ByCategory(int id)
        {
            var products = await _client
                .GetFromJsonAsync<List<ProductDto>>($"api/products/by-category/{id}");

            return View(products);
        }
    }
}