namespace OrderAPI.Models
{
    public class OrderModel
    {
        /// <summary>
        ///Код заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя официанта
        /// </summary>
        public string NameWaiter { get; set; }

        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime CreateOrder { get; set; }

        /// <summary>
        ///Код статуса
        /// </summary>
        public int IdStatus { get; set; }
    }
}
