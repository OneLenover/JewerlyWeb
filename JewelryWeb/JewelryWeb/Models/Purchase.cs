namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели закупки
    /// </summary>
    public class Purchase
    {
        /// <summary>
        /// Уникальный идентификатор закупки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор поставщика
        /// </summary>
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int ProductId { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// Количество закупленного товара
        /// </summary>
        public int QuantityProduct { get; set; }

        /// <summary>
        /// Цена за единицу товара, по которой закупили у поставщика
        /// </summary>
        public decimal Price {  get; set; }

        /// <summary>
        /// Дата закупки
        /// </summary>
        public DateTime Date {  get; set; }
    }
}
