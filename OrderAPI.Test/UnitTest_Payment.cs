using OrderAPI.Contract;
using OrderAPI.Service;

namespace OrderAPI.Test
{
    public class UnitTest_Payment
    {
        [Theory]
        [InlineData(80.75, 3, 83.17)]
        [InlineData(100, 5, 105)]
        public void PaymentWithGratuity_Test(decimal itog, int percent, decimal exp)
        {
            IServicePayment pay = new ServicePayment();

            decimal result = pay.PaymentWithGratuity(itog, percent);

            Assert.Equal(exp, result);
        }

       [Fact]
        public void PaymentWithGratuityException_Test()
        {
            IServicePayment pay = new ServicePayment();
            decimal itog = 0;
            int percent = 5;

            var ex = Assert.Throws<ArgumentException>(()=>pay.PaymentWithGratuity(itog,percent));
        }
    }
}