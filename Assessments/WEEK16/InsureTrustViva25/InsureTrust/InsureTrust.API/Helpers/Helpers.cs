namespace InsureTrust.API.Helpers;

public static class NumberGenerators
{
    public static string GeneratePaymentNumber(int id) => $"PAY{(id + 5000):D4}";
}
