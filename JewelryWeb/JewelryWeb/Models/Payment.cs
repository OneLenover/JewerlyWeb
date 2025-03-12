namespace JewelryWeb.Models
{
    /// <summary>
    /// Представляет платеж, связанный с заказом
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Уникальный идентификатор платежа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор заказа, к которому относится платеж
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Связанный заказ
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Дата и время проведения платежа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Общая сумма платежа
        /// </summary>
        public decimal TotalPayment { get; set; }

        /// <summary>
        /// Идентификатор типа платежа
        /// </summary>
        public int TypePaymentId { get; set; }

        /// <summary>
        /// Связанный тип платежа
        /// </summary>
        public TypePayment TypePayment { get; set; }
    }
}
