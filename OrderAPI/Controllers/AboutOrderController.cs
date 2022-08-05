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


        //public AboutOrderController(string sqlCon, IReportAboutOrder report)
        //{
        //    _sqlCon = sqlCon;
        //    _report = report;
        //}

        public AboutOrderController( IReportAboutOrder report)
        {
         //   _sqlCon = sqlCon;
            _report = report;
        }


        /// <summary>
        /// Вернуть шапку о заказе
        /// </summary>
        /// <param name="Credentials"></param>
        /// <returns></returns>
        [HttpGet("OrderInfo/{orderid}")]
        public async Task<ActionResult<OrderModel>> OrderInfo(int orderid)
        {
            return await _report.OrderInfo(orderid);
        }


        /// <summary>
        /// Вернуть содержимое указанных заказов
        /// </summary>
        /// <param name="Credentials"></param>
        /// <returns></returns>
        [HttpPost("OrdersContent")]
        public async Task <ActionResult<IEnumerable<OrderContentModel>>> OrdersContent([FromBody] OrdersPeriod orders)
        {
            return await _report.OrdersContent(orders);
        }
    }
}
