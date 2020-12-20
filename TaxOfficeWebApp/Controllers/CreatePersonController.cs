using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using TaxOfficeWebApp.Models;

namespace TaxOfficeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatePersonController : ControllerBase
    {
        private readonly TaxOfficeContext _context;
        private IConfiguration Configuration { get; }


        public CreatePersonController(TaxOfficeContext context)
        {
            _context = context;

            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
        }

        // GET: api/Entities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetEntity()
        {
            return await _context.Entity.ToListAsync();
        }

        // GET: api/Entities/5
        [HttpGet("{unp}")]
        public async Task<ActionResult<Entity>> GetEntity(string unp)
        {
            var entity = await _context.Entity.FindAsync(unp);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }



        // POST: api/createperson/entity
        [HttpPost, Route("entity")]
        public IActionResult CreateEntityPerson([FromBody]JObject data)
        {
            Entity entity = data["person"].ToObject<Entity>();
            string password = data["password"].ToObject<string>();

            var person_id = new SqlParameter()
            {
                ParameterName = "@person_id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            using var connection = new SqlConnection(Configuration.GetConnectionString("DevConnection"));
            using var cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "AddEntityPersons"
            };

            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@unp",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.Unp
                },
                new SqlParameter()
                {
                    ParameterName = "@org_title",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.ShortOrgTitle
                },
                new SqlParameter()
                {
                    ParameterName = "@f_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.FirstName
                },
                new SqlParameter()
                {
                    ParameterName = "@s_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.SecondName
                },
                new SqlParameter()
                {
                    ParameterName = "@m_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.MiddleName
                },
                new SqlParameter()
                {
                    ParameterName = "@passport",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.PassportNumber
                },
                new SqlParameter()
                {
                    ParameterName = "@address",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.OrgAddress
                },
                new SqlParameter()
                {
                    ParameterName = "@telephone",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = entity.Telephone
                },
                new SqlParameter()
                {
                    ParameterName = "@password",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = password
                },
                person_id
            };

            cmd.Parameters.AddRange(param1);
            connection.Open();

            cmd.ExecuteNonQuery();
            
            connection.Close();

            var response = new
            {
                personId = person_id.Value
            };

            return new JsonResult(response);
        }

        // POST: api/createperson/self
        [HttpPost, Route("self")]
        public IActionResult CreateSelfPerson([FromBody]JObject data)
        {
            SelfEmployed self = data["person"].ToObject<SelfEmployed>();
            string password = data["password"].ToObject<string>();

            var person_id = new SqlParameter()
            {
                ParameterName = "@person_id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            using var connection = new SqlConnection(Configuration.GetConnectionString("DevConnection"));
            using var cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "AddSelfEmployedPersons"
            };

            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@unp",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.Unp
                },
                new SqlParameter()
                {
                    ParameterName = "@org_title",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.ShortOrgTitle
                },
                new SqlParameter()
                {
                    ParameterName = "@f_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.FirstName
                },
                new SqlParameter()
                {
                    ParameterName = "@s_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.SecondName
                },
                new SqlParameter()
                {
                    ParameterName = "@m_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.MiddleName
                },
                new SqlParameter()
                {
                    ParameterName = "@passport",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.PassportNumber
                },
                new SqlParameter()
                {
                    ParameterName = "@address",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.OrgAddress
                },
                new SqlParameter()
                {
                    ParameterName = "@telephone",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = self.Telephone
                },
                new SqlParameter()
                {
                    ParameterName = "@password",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = password
                },
                person_id
            };

            cmd.Parameters.AddRange(param1);
            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

            var response = new
            {
                personId = person_id.Value
            };

            return new JsonResult(response);
        }

        // POST: api/createperson/individ
        [HttpPost, Route("individ")]
        public IActionResult CreateIndividPerson([FromBody]JObject data)
        {
            NaturalPersons individ = data["person"].ToObject<NaturalPersons>();
            string password = data["password"].ToObject<string>();

            var person_id = new SqlParameter()
            {
                ParameterName = "@person_id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            using var connection = new SqlConnection(Configuration.GetConnectionString("DevConnection"));
            using var cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "AddIndividualPersons"
            };

            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "@unp",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.Unp
                },
                new SqlParameter()
                {
                    ParameterName = "@f_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.FirstName
                },
                new SqlParameter()
                {
                    ParameterName = "@s_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.SecondName
                },
                new SqlParameter()
                {
                    ParameterName = "@m_name",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.MiddleName
                },
                new SqlParameter()
                {
                    ParameterName = "@passport",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.PassportCode
                },
                new SqlParameter()
                {
                    ParameterName = "@prnl_numb",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.PersonalNumber
                },
                new SqlParameter()
                {
                    ParameterName = "@address",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.PersonalAddress
                },
                new SqlParameter()
                {
                    ParameterName = "@telephone",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = individ.Telephone
                },
                new SqlParameter()
                {
                    ParameterName = "@password",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = password
                },
                person_id
            };

            cmd.Parameters.AddRange(param1);
            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();

            var response = new
            {
                personId = person_id.Value
            };

            return new JsonResult(response);
        }



        // POST: api/Entities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity(Entity entity)
        {
            _context.Entity.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntityExists(entity.Unp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntity", new { id = entity.Unp }, entity);
        }

        // DELETE: api/Entities/5
        [HttpDelete("{unp}")]
        public async Task<ActionResult<Entity>> DeleteEntity(string unp)
        {
            var entity = await _context.Entity.FindAsync(unp);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Entity.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        private bool EntityExists(string unp)
        {
            return _context.Entity.Any(e => e.Unp == unp);
        }
    }
}
