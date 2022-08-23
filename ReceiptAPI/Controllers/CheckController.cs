using Microsoft.AspNetCore.Mvc;
using ReceiptAPI.Models;
using ReceiptAPI.Service;
using System.Data;

namespace ReceiptAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private ReportCheck _check;
        private string _SqlCon = "";
        private readonly ILogger<CheckController> _logger;
        public CheckController(ReportCheck check, IConfiguration configuration, ILogger<CheckController> logger)
        {
            _check = check;
            _logger = logger;

            var cs = new ConnectStrings();
            configuration.GetSection(ConnectStrings.ConnectionStrings).Bind(cs);
            _SqlCon = cs.ReceiptDB;

        }


        [HttpGet("GetVersionPostgresql")]
        public async Task<ActionResult<string>> GetVersionPostgresql()
        {
            try
            {
                return await _check.GetVersionPostgresql(_SqlCon);
            }
            catch (Exception ex)
            {
                _logger.LogError("контроллер CheckController метод GetVersionPostgresql {numberError}", ex.Message);
                return null;
            }
        }

        [HttpGet("GetCheckInfo/{id}")]
        public async Task<ActionResult<List<CheckInfo>>> GetCheckInfo(int id)
        {
            try
            {
                return await _check.GetCheckInfo(id, _SqlCon);
            }
            catch (Exception ex)
            {
                _logger.LogError("контроллер CheckController метод GetCheckInfo {numberError}", ex.Message);
                return null;
            }

        }
    }
}
