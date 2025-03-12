namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели типа платежа
    /// </summary>
    public class TypePayment
    {
        /// <summary>
        /// Список типо оплаты
        /// </summary>
        public enum TypePay
        {
            /// <summary> Банковская карта </summary>
            BanlCard,
            /// <summary> Электронный кошелек </summary>
            EWallet,
            /// <summary> Наличные </summary>
            Cash,
            /// <summary> Банковский перевод </summary>
            BankTransfer
        }

        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип оплаты
        /// </summary>
        public TypePay Type { get; set; }

        /// <summary>
        /// Список оплат
        /// </summary>
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
