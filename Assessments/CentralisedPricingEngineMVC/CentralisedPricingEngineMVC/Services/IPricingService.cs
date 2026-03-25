namespace CentralisedPricingEngineMVC.Services
{
    public interface IPricingService
    {
        public decimal CalculatePrice(decimal baseprice, string promocode);
        public bool IsValidPromo(string promoCode);
    }
}
