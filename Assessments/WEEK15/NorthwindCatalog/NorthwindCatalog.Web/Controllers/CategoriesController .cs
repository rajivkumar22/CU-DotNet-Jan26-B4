using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.Models;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _client;

        public CategoriesController(IConfiguration config)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(config["ApiBaseUrl"])
            };
        }

        public async Task<IActionResult> Index()
        {
            var data = await _client
                .GetFromJsonAsync<List<CategoryDto>>("api/categories");

            return View(data);
        }

        
    }
}