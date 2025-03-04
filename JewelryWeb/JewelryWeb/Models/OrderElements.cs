﻿namespace JewelryWeb.Models
{
    public class OrderElements
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }
    }
}
