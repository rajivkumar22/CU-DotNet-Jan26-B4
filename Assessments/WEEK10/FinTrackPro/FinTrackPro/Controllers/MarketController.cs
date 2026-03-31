using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.Status = "Market Open";

            ViewData["TopGainer"] = "Tesla";

            ViewData["Volume"] = 1000000L;
            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker, int? days)
        {
            int period = days ?? 30;

            ViewBag.Ticker = ticker;
            ViewBag.Days = period;

            return View();
        }
    }
}
