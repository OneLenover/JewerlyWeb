namespace JewelryWeb.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public DateTime Date { get; set; }
        public decimal TotalPayment { get; set; }

        public int TypePaymentId { get; set; }
        public TypePayment TypePayment { get; set; }
    }
}
