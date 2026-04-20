using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.Models;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly HttpClient _client;

        public SummaryController(IConfiguration config)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(config["ApiBaseUrl"])
            };
        }

        public async Task<IActionResult> Index()
        {
            var summary = await _client
                .GetFromJsonAsync<List<CategorySummaryDto>>("api/products/summary");

            return View(summary);
        }
    }
}