using InsureTrust.Web.Models;
using InsureTrust.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Initiate", "Payment");
    }
}

public class PaymentController : Controller
{
    private readonly ApiClient _api;
    public PaymentController(ApiClient api) => _api = api;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var history = await _api.GetPaymentHistoryAsync() ?? new List<PaymentViewModel>();
        return View(history);
    }

    [HttpGet]
    public IActionResult Initiate()
    {
        var model = new InitiatePaymentViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Initiate(InitiatePaymentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            var payment = await _api.InitiatePaymentAsync(model);
            if (payment != null)
            {
                TempData["Success"] = $"Payment of {payment.Amount:C} processed successfully. Reference: {payment.PaymentNumber}";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Payment processing failed. Please try again.");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View(model);
    }
}
