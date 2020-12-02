using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using TaxOfficeWebApp.Models;
using Microsoft.Extensions.Configuration;

namespace TaxOfficeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtInfoController : ControllerBase
    {
        private IConfiguration Configuration { get; }

        public DebtInfoController()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
        }

        // GET: api/DebtInfo
        [HttpGet("{unp}")]
        public IEnumerable<object> Get(string unp)
        {
            List<object> list = new List<object>();
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DevConnection")))
            {
                using var cmd = new SqlCommand
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "GetDebtInfo"
                };

                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@unp",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = unp
                };

                cmd.Parameters.Add(param1);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            checkId = reader.GetValue(0),
                            title = reader.GetValue(1),
                            debtSum = reader.GetValue(2),
                            debtBillingDate = reader.GetValue(3) ,
                            debtPayedDate = reader.GetValue(4) is DBNull ? "" : reader.GetValue(4),
                            isPayed = reader.GetValue(5)
                        });
                    }
                }
            }
            return list;
        }

        // GET: api/DebtInfo/500200300
        //[HttpGet("{unp}", Name = "Get")]
        //public List<object> Get(string unp)
        //{

        //}
    }
}
