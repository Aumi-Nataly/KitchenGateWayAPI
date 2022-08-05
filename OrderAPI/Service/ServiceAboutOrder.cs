using Dapper;
using Microsoft.Extensions.Options;
using OrderAPI.Contract;
using OrderAPI.Helpers;
using OrderAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace OrderAPI.Service
{
    public class ServiceAboutOrder : IReportAboutOrder
    {
        private string _SqlCon="";
        private readonly IConfiguration _conf;

        //public ServiceAboutOrder(IOptions<string> SqlCon)
        //{
        //    _SqlCon = SqlCon.Value;
        //}

        public ServiceAboutOrder(IConfiguration configuration)
        {
            _conf = configuration;

            var cs = new ConnectStrings();
            _conf.GetSection(ConnectStrings.ConnectionStrings).Bind(cs);

            _SqlCon = cs.OrderDB;
        }

        public async Task<OrderModel> OrderInfo(int orderid)
        {
            string query = "procOrderInfo";

            try
            {
                using (SqlConnection con = new SqlConnection(_SqlCon))
                {
                    con.Open();

                    var param = new DynamicParameters();

                    param.Add("@orderid", orderid, dbType: DbType.Int32);

                    var result = await con.QueryAsync<OrderModel>(query, param, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderContentModel>> OrdersContent(OrdersPeriod orders)
        {
            string query = "procOrdersContent";

            try
            {
                using (SqlConnection con = new SqlConnection(_SqlCon))
                {
                    con.Open();

                    var param = new DynamicParameters();

                    param.Add("@ListOrder", orders.OrderId, dbType: DbType.Object);
                    param.Add("@dtStart", orders.dtSt, dbType: DbType.DateTime);
                    param.Add("@dtEnd", orders.dtEnd, dbType: DbType.DateTime);


                    var result = await con.QueryAsync<OrderContentModel>(query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
