using Npgsql;
using ReceiptAPI.Models;
using System.Data;

namespace ReceiptAPI.Service
{
    public class ReportCheck
    {
        /// <summary>
        /// Узнать версию Postgres
        /// </summary>
        /// <param name="constr"></param>
        /// <returns></returns>
        public async Task<string> GetVersionPostgresql(string constr)
        {
          
            string version="";
            using (var con = new NpgsqlConnection(constr))
            {
                await con.OpenAsync();

                var sql = "SELECT version()";
                NpgsqlCommand command = new NpgsqlCommand(sql, con);

                version = (string)await command.ExecuteScalarAsync();
            }

            return version;
        }

        /// <summary>
        /// Вывести информацию о чеке
        /// </summary>
        /// <param name="id"></param>
        /// <param name="constr"></param>
        /// <returns></returns>
        public async Task<List<CheckInfo>> GetCheckInfo(int id, string constr)
        {
           
            List<CheckInfo> list = new List<CheckInfo>();

            using (var con = new NpgsqlConnection(constr))
            {
                using (NpgsqlCommand sqlComm = new NpgsqlCommand("select * from getreceiptInfo(@idrec)", con))
                {
                    sqlComm.Parameters.AddWithValue("@idrec", id);
                    
                    await con.OpenAsync();

                    using (var reader = await sqlComm.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                       
                       while(reader.Read())
                        {
                            list.Add(
                                new CheckInfo { 
                                Id = Convert.ToInt32(reader["id"]),
                                DateAdd = Convert.ToDateTime(reader["dateadd"]),
                                ProductName = reader["product_name"].ToString(),
                                Money= Convert.ToDecimal(reader["price"])
                            });

                        }
                    }
                }
            }

            return list;
        }

    }
}
