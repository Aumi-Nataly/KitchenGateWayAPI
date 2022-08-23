using Microsoft.AspNetCore.Mvc;
using OrderAPI.Contract;
using OrderAPI.Helpers;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutOrderController : Controller
    {
        private string _sqlCon;
        private IReportAboutOrder _report;
        private readonly ILogger<AboutOrderController> _logger;



        public AboutOrderController(IReportAboutOrder report, ILogger<AboutOrderController> logger)
        {
            //   _sqlCon = sqlCon;
            _report = report;
            _logger = logger;
        }


        /// <summary>
        /// Вернуть шапку о заказе
        /// </summary>
        /// <param name="Credentials"></param>
        /// <returns></returns>
        [HttpGet("OrderInfo/{orderid}")]
        public async Task<ActionResult<OrderModel>> OrderInfo(int orderid)
        {
            try
            {
                return await _report.OrderInfo(orderid);
            }
            catch (Exception ex)
            {
                _logger.LogError("контроллер AboutOrderController метод OrderInfo {numberError}", ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Вернуть содержимое указанных заказов
        /// </summary>
        /// <param name="Credentials"></param>
        /// <returns></returns>
        [HttpPost("OrdersContent")]
        public async Task<ActionResult<IEnumerable<OrderContentModel>>> OrdersContent([FromBody] OrdersPeriod orders)
        {
            try
            {
                return await _report.OrdersContent(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError("контроллер AboutOrderController метод OrdersContent {numberError}", ex.Message);
                return null;
            }
        }
    }
}
