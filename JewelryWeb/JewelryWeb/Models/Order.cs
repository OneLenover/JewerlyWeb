namespace JewelryWeb.Models
{
    /// <summary>
    /// Статусы заказа
    /// </summary>
    public enum OrderStatus
    {
        /// <summary> Заказа ожидает обработки </summary>
        Pending,
        /// <summary> Заказ отправлен </summary>
        Shipped,
        /// <summary> Заказа доставлен </summary>
        Delivered,
        /// <summary> Заказ отменен </summary>
        Canceled
    }

    /// <summary>
    /// Описание модели заказа
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Уникальный идентификатор заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор клиента, сделавший заказ
        /// </summary>
        public int ClientId { get; set; }
        public Client Client { get; set; }

        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Общая стоимость заказа
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Адрес доставки заказа
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Информация об оплате заказа
        /// </summary>
        public Payment Payments { get; set; }

        /// <summary>
        /// Список элементов, входящих в заказ
        /// </summary>
        public ICollection<OrderElements> OrdersElements { get; set; } = new List<OrderElements>();
    }
}
