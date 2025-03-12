namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели отзывов
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Уникальный идентификатор отзыва
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int ProductId { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public int ClientId { get; set; }
        public Client Client { get; set; }

        /// <summary>
        /// Оценка товара
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата написания отзыва
        /// </summary>
        public DateTime Date { get; set; }
    }
}
