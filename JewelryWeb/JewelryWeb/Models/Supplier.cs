﻿namespace JewelryWeb.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
