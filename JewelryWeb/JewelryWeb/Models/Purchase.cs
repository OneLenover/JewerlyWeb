namespace JewelryWeb.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int QuantityProduct { get; set; }
        public decimal Price {  get; set; }
        public DateTime Date {  get; set; }
    }
}
