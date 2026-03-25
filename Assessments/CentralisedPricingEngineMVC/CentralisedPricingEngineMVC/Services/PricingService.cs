namespace CentralisedPricingEngineMVC.Services
{
    public class PricingService:IPricingService
    {
        public decimal CalculatePrice(decimal baseprice,string promocode)
        {
            decimal finalprice = baseprice;
            if (string.IsNullOrEmpty(promocode)) return baseprice;
            if (promocode.ToUpper() == "WINTER25")
            {
                return finalprice * 0.85m;
            }
            if (promocode.ToUpper() == "FREESHIP")
            {
                return finalprice - 5m;
            }
            return finalprice;


        }
        public bool IsValidPromo(string promoCode)
        {

            if (string.IsNullOrEmpty(promoCode))
                return false;

            string code = promoCode.ToUpper();

            return code == "WINTER25" || code == "FREESHIP";
        }

    }
}
