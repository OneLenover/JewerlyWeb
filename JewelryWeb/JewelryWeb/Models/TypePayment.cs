namespace JewelryWeb.Models
{
    public class TypePayment
    {
        public enum TypePay
        {
            BanlCard,
            EWallet,
            Cash,
            BankTransfer
        }

        public int Id { get; set; }
        public TypePay Type { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
