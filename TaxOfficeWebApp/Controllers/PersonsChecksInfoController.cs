using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TaxOfficeWebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin, employee, user")]
    [ApiController]
    public class PersonsChecksInfoController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public PersonsChecksInfoController()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
        }

        // GET: api/PersonsChecksInfo/
        [HttpGet("{deadline}")]
        public IEnumerable<object> GetBankChecks(string deadline)
        {
            List<object> list = new List<object>();
            using var connection = new SqlConnection(Configuration.GetConnectionString("DevConnection"));
            using var cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "GetBankChecksWithPersonInfo"
            };

            SqlParameter param1 = new SqlParameter()
            {
                ParameterName = "@deadline",
                SqlDbType = System.Data.SqlDbType.Date,
                Value = deadline.Replace('-', '/')
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
                        unp = reader.GetValue(0),
                        fName = reader.GetValue(1),
                        mName = reader.GetValue(2),
                        sName = reader.GetValue(3),
                        checkId = reader.GetValue(4),
                        fkRegPerson = reader.GetValue(5),
                        checkTitle = reader.GetValue(6),
                        finalSum = reader.GetValue(7),
                        payedDate = reader.GetValue(8),
                        isDebtRep = reader.GetValue(9),
                        isCorrect = reader.GetValue(10)
                    });
                }
            }
            return list;
        }
    }
}
