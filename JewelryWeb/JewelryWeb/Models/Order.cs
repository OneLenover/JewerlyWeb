namespace JewelryWeb.Models
{
    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Canceled
    }

    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalCost { get; set; }
        public string Address { get; set; }
    
        public Payment Payments { get; set; }
        public ICollection<OrderElements> OrdersElements { get; set; } = new List<OrderElements>();
    }
}
