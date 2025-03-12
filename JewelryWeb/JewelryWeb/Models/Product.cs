namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели товара
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        /// <summary>
        /// Идентификатор материала
        /// </summary>
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество товара на складе
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Список отзывов, относящихся к этому товару
        /// </summary>
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        /// <summary>
        /// Список элеметов заказаов, относящихся к этому товару
        /// </summary>
        public ICollection<OrderElements> OrdersElements { get; set; } = new List<OrderElements>();

        /// <summary>
        /// Список закупок, в которых был закуплен товар
        /// </summary>
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
