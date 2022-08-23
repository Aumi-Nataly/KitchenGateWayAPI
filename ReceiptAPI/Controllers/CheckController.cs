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
        public CheckController(ReportCheck check, IConfiguration configuration)
        {
            _check=check;

            var cs = new ConnectStrings();
            configuration.GetSection(ConnectStrings.ConnectionStrings).Bind(cs);
            _SqlCon = cs.ReceiptDB;

        }


        [HttpGet("GetVersionPostgresql")]
        public async Task<ActionResult<string>> GetVersionPostgresql()
        {
            return await _check.GetVersionPostgresql(_SqlCon);
            
        }

        [HttpGet("GetCheckInfo/{id}")]
        public async Task<ActionResult<List<CheckInfo>>> GetCheckInfo(int id)
        {
            return await _check.GetCheckInfo(id, _SqlCon);

        }
    }
}
