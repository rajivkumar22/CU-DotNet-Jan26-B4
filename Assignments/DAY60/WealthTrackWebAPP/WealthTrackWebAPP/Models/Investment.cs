namespace WealthTrackWebAPP.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; } // e.g., "SILVERBEES"
        public string AssetName { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public decimal InvestedValue => PurchasePrice * Quantity;
        public DateTime PurchaseDate { get; set; }

    }
}
