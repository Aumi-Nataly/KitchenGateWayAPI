namespace OrderAPI.Contract
{   
    /// <summary>
     /// расчет итоговой суммы оплаты заказа, учитвая скидки, чаевые и др факторы
     /// </summary>
    public interface IServicePayment
    {
        /// <summary>
        /// Прибавка чаевых с указанным процентом
        /// </summary>
        /// <param name="itog"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public decimal PaymentWithGratuity(decimal itog, int percent);
    }
}
