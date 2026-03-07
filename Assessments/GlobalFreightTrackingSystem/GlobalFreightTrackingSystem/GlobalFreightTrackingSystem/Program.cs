namespace GlobalFreightTrackingSystem
{
    public class RestrictedDestinationException : Exception {

        public string Restricted{ get;  }
        public RestrictedDestinationException(string location) 
        {
            Restricted = location;
        }
    }
    public class InsecurePackagingException : Exception
    {

        public InsecurePackagingException() { 
        }
    }
    public abstract class Shipment
    {
        public string TrackingId{ get; set; }
        public double weight { get; set; }
        public string Destination{ get; set; }

        public abstract void ProcessShipment();

    }
    public class ExpressShipment : Shipment {
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }

        public override void ProcessShipment()
        {
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
             if(Destination=="North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }
            if(IsFragile && !IsReinforced)
            {
                throw new InsecurePackagingException();
            }
        }

    }
    public class HeavyFreight : Shipment {
        
        public override void ProcessShipment()
        {
            if (weight <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }
            if (weight > 1000)
            {
                throw new Exception("HeavyLift permit required");
            }
          
        }
    }
    public interface ILoggable
    {
        void SaveLog(string message);
    }
    public class LogManager : ILoggable
    {
        string auditlog = @"..\..\..\_audit.log";
        public void SaveLog(string message)
        {
            using (StreamWriter sw=new StreamWriter(auditlog, true))
            {
                sw.WriteLine(message);
            }
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            ILoggable logger = new LogManager();
            List<Shipment> shipments = new List<Shipment>() {

                new ExpressShipment{
                    TrackingId="101",
                    weight=1200,
                    Destination="DELHI"
                },
                 new ExpressShipment{
                    TrackingId="102",
                    weight=1200,
                    Destination="Patna",
                    IsFragile=true,
                    IsReinforced=false

                },
                  new HeavyFreight{
                    TrackingId="103",
                    weight=1300,
                    Destination="Pune"
                    

                },
                   new ExpressShipment{
                    TrackingId="105",
                    weight=200,
                    Destination="NorthPole",
                    IsFragile=true,
                    IsReinforced=true

                },


            };

            foreach(var shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    logger.SaveLog($"Success:{shipment.TrackingId}");
                }
                catch (RestrictedDestinationException)
                {
                    logger.SaveLog("Security Alert");
                }
                catch (ArgumentOutOfRangeException)
                {
                    logger.SaveLog("Data Entry Error");
                }
                catch(Exception ex)
                {
                    logger.SaveLog(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {shipment.TrackingId}.");
                }
            }
            

        }
    }
}
