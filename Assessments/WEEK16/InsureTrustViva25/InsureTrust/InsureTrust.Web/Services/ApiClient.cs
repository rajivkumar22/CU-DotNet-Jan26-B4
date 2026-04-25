using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using InsureTrust.Web.Models;

namespace InsureTrust.Web.Services;

public class ApiClient
{
    private readonly HttpClient _http;
    private readonly IHttpContextAccessor _ctx;
    private readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };

    public ApiClient(IHttpClientFactory factory, IHttpContextAccessor ctx)
    {
        _http = factory.CreateClient("API");
        _ctx = ctx;
    }

    private async Task<T?> GetAsync<T>(string url)
    {
        var res = await _http.GetAsync(url);
        if (!res.IsSuccessStatusCode) return default;
        var json = await res.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, _json);
    }

    private async Task<T?> PostAsync<T>(string url, object data)
    {
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        var res = await _http.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode) throw new Exception(ExtractMessage(json));
        return JsonSerializer.Deserialize<T>(json, _json);
    }

    private string ExtractMessage(string json)
    {
        try { var doc = JsonDocument.Parse(json); return doc.RootElement.GetProperty("message").GetString() ?? json; }
        catch { return json; }
    }

    // Payments
    public async Task<PaymentViewModel?> InitiatePaymentAsync(InitiatePaymentViewModel model)
    {
        var result = await PostAsync<JsonElement>("api/payment/initiate", model);
        if (result.ValueKind == JsonValueKind.Undefined) return null;
        if (result.TryGetProperty("data", out var pEl) || result.TryGetProperty("payment", out pEl))
        {
            var raw = pEl.GetRawText();
            return JsonSerializer.Deserialize<PaymentViewModel>(raw, _json);
        }
        return null;
    }

    public async Task<List<PaymentViewModel>?> GetPaymentHistoryAsync()
    {
        var result = await GetAsync<JsonElement>("api/payment/history");
        if (result.ValueKind == JsonValueKind.Undefined) return new List<PaymentViewModel>();
        if (result.TryGetProperty("data", out var historyEl) || result.TryGetProperty("payments", out historyEl))
        {
            var raw = historyEl.GetRawText();
            return JsonSerializer.Deserialize<List<PaymentViewModel>>(raw, _json);
        }
        return new List<PaymentViewModel>();
    }
}
