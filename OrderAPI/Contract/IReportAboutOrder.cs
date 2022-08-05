using OrderAPI.Helpers;
using OrderAPI.Models;

namespace OrderAPI.Contract
{
    /// <summary>
    /// Получение различных отчетов о заказах
    /// </summary>
    public interface IReportAboutOrder
    {
        /// <summary>
        /// Вернуть все заказы за указанный день
        /// </summary>
        /// <param name="dtSt"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public Task<OrderModel> OrderInfo(int orderid);

        /// <summary>
        /// Вернуть содержимое указанных заказов
        /// </summary>
        /// <param name="dtSt"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public Task<List<OrderContentModel>> OrdersContent(OrdersPeriod orders);

    }
}
