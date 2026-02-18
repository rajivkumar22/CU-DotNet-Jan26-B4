
namespace Day15Project
{

    class Order
    {
       
        private DateTime orderdate;
        private string orderstatus;
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private bool _applieddiscount;
        public Order()
        {
            orderdate = DateTime.Now;
            orderstatus = "NEW";
            

        }
        public Order(int _orderId, string _customerName):this()
        {
            this._orderId = _orderId;
            this._customerName = _customerName;

        }

        public int orderId { get { return _orderId; } }


        public string customerName
        {
            get { return _customerName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _customerName = value;
                }
            }
        }

        public void AddItem(decimal price)
        {
            if (price > 0)
            {
                _totalAmount += price;

            }
        }
        public void ApplyDiscount(decimal percentage)
        {
            if(_applieddiscount) Console.WriteLine("One time discount,sorry ");
            if (percentage >= 1 && percentage <= 30)
            {
                decimal discount = _totalAmount * percentage / 100;
                _totalAmount -= discount;
                _applieddiscount = true;
            }
        }
        public string GetOrderSummary()
        {
            return $"orderId: {_orderId} Customer name: {_customerName} TotalAmount: {_totalAmount} Status: {orderstatus}";
        }

        public decimal TotalAmount { get { return _totalAmount; } }
        internal class Order1
        {
            static void Main(string[] args)
            {
                Order order = new Order(101, "Rajiv");
                order.AddItem(500);
                order.AddItem(500);
                order.ApplyDiscount(10);
                
                Console.WriteLine(order.GetOrderSummary());
                order.ApplyDiscount(10);
            }
        }
    }
}
