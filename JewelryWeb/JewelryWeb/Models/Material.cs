namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели материлов
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Уникальный идентификатор материала
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название материла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание материала
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Коллекция товаров, связанных с к этому материалу
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
