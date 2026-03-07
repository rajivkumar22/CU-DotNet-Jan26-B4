using Microsoft.AspNetCore.Mvc;

namespace MVCWebApp.Controllers
{
    public class webmvcController1 : Controller
    {
        public IActionResult Greet()
        {
            return View();
        }
    }
}
