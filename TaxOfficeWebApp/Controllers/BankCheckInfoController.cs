using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace TaxOfficeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCheckInfoController
    {
        private IConfiguration Configuration { get; }

        public BankCheckInfoController()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
        }

        // GET: api/BankCheckInfo/503612177
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
                    CommandText = "GetBankCheckInfo"
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
                            regPersonId = reader.GetValue(1),
                            title = reader.GetValue(2),
                            finalSum = reader.GetValue(3),
                            payedDate = reader.GetValue(4),
                            isDebtRepayment = reader.GetValue(5)
                        });
                    }
                }
            }
            return list;
        }
    }
}
