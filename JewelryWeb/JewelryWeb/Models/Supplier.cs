namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели поставщика
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Уникальный идентификатор поставщика
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название поставщика
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона поставщика
        /// </summary>
        public string PhoneNumber {  get; set; }

        /// <summary>
        /// Почта поставщика
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Адрес поставщика
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Список поставок этого поставщика
        /// </summary>
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
