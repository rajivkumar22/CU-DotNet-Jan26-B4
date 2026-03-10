using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace FinancialPortfolioManagement
{
    public class InvalidFinancialDataException : Exception {
        public InvalidFinancialDataException(string message) : base(message) { }
    
    }

  public  abstract class FinancialInstrument
    {
        public string ?InstrumentId { get; set; }
        public string ?Name{ get; set; }
        private string currency;
        private decimal purchaseprice;
        private decimal marketprice;
        
        
       
        private int quantity { get; set; }
         public DateOnly PurchaseDate { get; set; }
     
       
        public string Currency
        {
            get { return currency; }
            set
            {
                if (value.Length != 3)
                {
                    throw new InvalidFinancialDataException("currency must be 3 letters");
                    
                }
                currency = value;
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidFinancialDataException("Quantity cannot be negative");

                }
                quantity = value;
            }

        }
        public decimal PurchasePrice
        {
            get { return purchaseprice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Purchase price cannot be negative.");
                purchaseprice = value;
            }
        }
        public decimal MarketPrice
        {
            get { return marketprice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Market price cannot be negative.");
                marketprice = value;
            }
        }



        //  public   FinancialInstrument(int instrumentid,string name,decimal currency,)
        public abstract decimal CalculateCurrentValue();
        public virtual string GetInstrumentSummary()
        {
            return "this is a Financial Instrument";
        }

    }
    public interface IRiskAssessable
    {
        public string GetRiskCategory();
    }
    public interface IReportable
    {
        public string GenerateReportLine();
    }
    public class Equity : FinancialInstrument,IRiskAssessable, IReportable

    {
        public string GetRiskCategory()
        {
            return "High";
        }

        public string GenerateReportLine()
        {
            return $"Equity | {Name} | Value: {CalculateCurrentValue()}";
        }

        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
       

    }
    public class Bond : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
        public override string GetInstrumentSummary()
        {
            return " ";
        }
    }
    public class FixedDeposit : FinancialInstrument, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
        public string GenerateReportLine()
        {
            return $"FixedDeposit | {Name} | Value: {CalculateCurrentValue()}";
        }
    }
    public class MutualFund : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
        public string GetRiskCategory()
        {
            return "Low";
        }

        public string GenerateReportLine()
        {
            return $"MutualFund | {Name} | Value: {CalculateCurrentValue()}";
        }
    }
  
    public class Portfolio
    {
       private List<FinancialInstrument> financialInstruments = new List<FinancialInstrument>();
        private Dictionary<string, FinancialInstrument> dict = new Dictionary<string, FinancialInstrument>();
        public void AddInstrument(FinancialInstrument instrument)
        {
            if (!dict.ContainsKey(instrument.InstrumentId)){
                dict.Add(instrument.InstrumentId, instrument);
                financialInstruments.Add(instrument);

            }
        }
       // List<FinancialInstrument> removeinstrument = new List<FinancialInstrument>();
        public bool RemoveInstrument(string KeyToRemove)
        {
            if (dict.ContainsKey(KeyToRemove))
            {
                var temp = dict[KeyToRemove];
                financialInstruments.Remove(temp);
                return true;
                
            }
            else
            {
                return false;
            }
        }
        public decimal GetTotalPortfolioValue()
        {
            return financialInstruments.Sum(i => i.CalculateCurrentValue());
        }
        public FinancialInstrument GetInstrumentById(String instrumentid)
        {



            if (!dict.ContainsKey(instrumentid))
            {
                throw new Exception("Instrument not found.");
            }
                return dict[instrumentid];
                
        }
        public List<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            return financialInstruments
                .OfType<IRiskAssessable>()
                .Where(r => r.GetRiskCategory() == risk)
                .Cast<FinancialInstrument>()
                .ToList();
        }
        public List<FinancialInstrument> GetAll()
        {
            return financialInstruments;
        }




    }
    public class Transaction {


        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }   
        public int Units { get; set; }
        public DateTime Date { get; set; }

        public void TransactionProcess(Transaction[]Transactionarray,Portfolio portfolio)
        {
            List<Transaction> transactions = Transactionarray.ToList();
             foreach(var tx in transactions)
            {
                var instrument = portfolio.GetInstrumentById(tx.InstrumentId);
                if (tx.Type == "Buy")
                {
                    instrument.Quantity += tx.Units;
                }
                else if (tx.Type == "Sell")
                {
                    if (instrument.Quantity < tx.Units)
                    {
                        throw new InvalidFinancialDataException("Selling more than earned");
                    }
                    instrument.Quantity -= tx.Units;
                }
                
            }
        }


    }


    public class ReportGenerator
    {
        public void GenerateReport(Portfolio portfolio)
        {
            Console.WriteLine("Portfolio Summary:");
            var grouped = portfolio.GetAll()
               .GroupBy(i => i.GetType().Name);

            foreach (var group in grouped)
            {

                decimal investment = group.Sum(i => i.PurchasePrice * i.Quantity);
                decimal current = group.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"\nInstrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {investment:C}");
                Console.WriteLine($"Current Value: {current:C}");
                Console.WriteLine($"Profit/Loss: {(current - investment):C}");
            }
        }
        public void GenerateFileReport(Portfolio portfolio)
{
    string fileName = @"..\..\..\PortfolioReport_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

    try
    {
        using (StreamWriter sw = new StreamWriter(fileName, true))
        {
            sw.WriteLine("===== PORTFOLIO REPORT =====");
            sw.WriteLine("Generated On: " + DateTime.Now);
            sw.WriteLine();

            foreach (var instrument in portfolio.GetAll())
            {
                sw.WriteLine(instrument.InstrumentId + " | " +
                             instrument.Name + " | " +
                             instrument.CalculateCurrentValue().ToString("C"));
            }

            sw.WriteLine();
            sw.WriteLine("Total Portfolio Value: " +
                portfolio.GetTotalPortfolioValue().ToString("C"));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("File error: " + ex.Message);
    }
}




    }
       


    internal class Program
    {
        static void Main(string[] args)
        {
           Portfolio portfolio = new Portfolio();

            Equity e = new Equity()
            {
                InstrumentId = "EQ001",
                Name = "INFY",
                Currency = "INR",
                Quantity = 100,
                PurchasePrice = 1500,
                MarketPrice = 1650
            };

            Bond b = new Bond()
            {
                InstrumentId = "BD001",
                Name = "GovBond",
                Currency = "INR",
                Quantity = 50,
                PurchasePrice = 1000,
                MarketPrice = 1050
            };

            MutualFund mf = new MutualFund()
            {
                InstrumentId = "MF001",
                Name = "SBI Fund",
                Currency = "INR",
                Quantity = 200,
                PurchasePrice = 100,
                MarketPrice = 120
            };

            portfolio.AddInstrument(e);
            portfolio.AddInstrument(b);
            portfolio.AddInstrument(mf);

            Transaction[] txs =
            {
                new Transaction{TransactionId="T1",InstrumentId="EQ001",Type="Buy",Units=10,Date=DateTime.Now},
                new Transaction{TransactionId="T2",InstrumentId="MF001",Type="Sell",Units=20,Date=DateTime.Now}
            };

            Transaction t = new Transaction();
            t.TransactionProcess(txs, portfolio);

            ReportGenerator rg = new ReportGenerator();
            rg.GenerateReport(portfolio);
            rg.GenerateFileReport(portfolio);
        
            
        }
    }
}
