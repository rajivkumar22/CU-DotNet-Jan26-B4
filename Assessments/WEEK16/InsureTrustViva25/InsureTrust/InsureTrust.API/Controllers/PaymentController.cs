using System.Security.Claims;
using InsureTrust.API.DTOs.Payment;
using InsureTrust.API.Services;
using InsureTrust.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsureTrust.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _svc;
    public PaymentController(IPaymentService svc) => _svc = svc;

    [HttpPost("initiate")]
    public async Task<IActionResult> Initiate([FromBody] InitiatePaymentDto dto)
    {
        // For demonstration, defaulting to UserId = 1 if no claim found
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = string.IsNullOrEmpty(userIdClaim) ? 1 : int.Parse(userIdClaim);

        var payment = await _svc.InitiateAsync(dto, userId);
        return Ok(ApiResponse<PaymentDto>.SuccessResponse(payment, "Payment initiated successfully."));
    }

    [HttpGet("history")]
    public async Task<IActionResult> History()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = string.IsNullOrEmpty(userIdClaim) ? 1 : int.Parse(userIdClaim);
        
        var history = await _svc.GetHistoryAsync(userId);
        return Ok(ApiResponse<IEnumerable<PaymentDto>>.SuccessResponse(history, "Payment history retrieved successfully."));
    }
}
