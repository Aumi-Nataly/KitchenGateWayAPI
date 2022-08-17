using OrderAPI.Contract;

namespace OrderAPI.Service
{
    /// <summary>
    /// расчет итоговой суммы оплаты заказа, учитывая скидки, чаевые и др факторы
    /// </summary>
    public class ServicePayment : IServicePayment
    {
        public decimal PaymentWithGratuity(decimal itog, int percent)
        {
            if (itog == 0)
                throw new ArgumentException("Нулевая сумма заказа",nameof(itog));

            var summa = itog * (100 + percent) / 100;

            return decimal.Round(summa,2);
        }
    }
}
