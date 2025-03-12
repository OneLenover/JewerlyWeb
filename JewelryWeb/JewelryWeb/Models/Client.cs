namespace JewelryWeb.Models
{
    /// <summary>
    /// Описание модели клиента
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Идентификатор модели пользователя связанного с клиентом
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Учетная запись пользователя связанного с клиентом
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Коллекция отзывов, оставленных клиентом
        /// </summary>
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        /// <summary>
        /// Коллекция заказов клиента
        /// </summary>
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
