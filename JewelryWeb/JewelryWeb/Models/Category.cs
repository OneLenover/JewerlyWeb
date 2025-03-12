namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели категории
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор категории
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание категории
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Коллекция товаров, относящихся к этой категоии
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
