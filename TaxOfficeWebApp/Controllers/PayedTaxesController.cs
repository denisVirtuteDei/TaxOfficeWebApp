using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxOfficeWebApp.Models;

namespace TaxOfficeWebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin, employee, user")]
    [ApiController]
    public class PayedTaxesController : ControllerBase
    {
        private readonly TaxOfficeContext _context;
        private readonly IConfiguration Configuration;



        //// GET: api/PayedTaxes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PayedTaxes>> GetPayedTaxes(int id)
        //{
        //    var payedTaxes = await _context.PayedTaxes.FindAsync(id);

        //    if (payedTaxes == null)
        //    {
        //        return NotFound();
        //    }

        //    return payedTaxes;
        //}

        public PayedTaxesController(TaxOfficeContext context)
        {
            _context = context;

            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
        }

        // GET: api/PayedTaxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayedTaxes>>> GetPayedTaxes()
        {
            return await _context.PayedTaxes.ToListAsync();
        }


        // GET: api/PayedTaxesInfo/{date} , Route("api/PayedTaxesInfo")
        [HttpGet("{deadline}")]
        public IEnumerable<object> GetPayedTaxesInfo(string deadline)
        {
            List<object> list = new List<object>();
            using var connection = new SqlConnection(Configuration.GetConnectionString("DevConnection"));
            using var cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "GetPayedTaxesWithPersonInfo"
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
                        checkTitle = reader.GetValue(4),
                        taxesId = reader.GetValue(5),
                        fkNcea = reader.GetValue(6),
                        fkBankCheck = reader.GetValue(7),
                        taxAmount = reader.GetValue(8),
                        isCorrect = reader.GetValue(9)
                    });
                }
            }
            return list;
        }

        // PUT: api/PayedTaxes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayedTaxes(int id, PayedTaxes payedTaxes)
        {
            if (id != payedTaxes.Id)
            {
                return BadRequest();
            }

            _context.Entry(payedTaxes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayedTaxesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PayedTaxes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PayedTaxes>> PostPayedTaxes(PayedTaxes payedTaxes)
        {
            _context.PayedTaxes.Add(payedTaxes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayedTaxes", new { id = payedTaxes.Id }, payedTaxes);
        }

        // DELETE: api/PayedTaxes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<PayedTaxes>> DeletePayedTaxes(int id)
        //{
        //    var payedTaxes = await _context.PayedTaxes.FindAsync(id);
        //    if (payedTaxes == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PayedTaxes.Remove(payedTaxes);
        //    await _context.SaveChangesAsync();

        //    return payedTaxes;
        //}

        private bool PayedTaxesExists(int id)
        {
            return _context.PayedTaxes.Any(e => e.Id == id);
        }
    }
}
