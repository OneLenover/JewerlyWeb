namespace JewelryWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<OrderElements> OrdersElements { get; set; } = new List<OrderElements>();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
