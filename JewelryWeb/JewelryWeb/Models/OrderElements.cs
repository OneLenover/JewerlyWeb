namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели элементы заказа
    /// </summary>
    public class OrderElements
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
        public Order Order { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int ProductId { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// Количество купленного клиентом товара
        /// </summary>
        public int ProductQuantity { get; set; }

        /// <summary>
        /// Цена за единицу товара на момент оформления заказа
        /// </summary>
        public decimal Price { get; set; }
    }
}
