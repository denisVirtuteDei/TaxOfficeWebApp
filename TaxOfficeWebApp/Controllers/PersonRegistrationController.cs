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
    public class PersonRegistrationController : ControllerBase
    {

        private readonly TaxOfficeContext _context;


        public PersonRegistrationController(TaxOfficeContext context)
        {
            _context = context;
        }

        // POST: api/EconomicActivityTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PersonRegistrations>> PostPersonReg(PersonRegistrations pr)
        {
            _context.PersonRegistrations.Add(pr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonRegistrationExists(pr.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonRegistration", new { pr.Id }, pr);
        }

        // GET: api/personregistration/username?`${LowSkill228}`
        [HttpGet("{username}"), Route("/username")]
        public async Task<ActionResult<int>> GetExecutor(string username)
        {
            var executors = await (
                from u in _context.Users
                join e in _context.Executors on u.Id equals e.FkUser
                where u.UserLogin == username
                select e.Id
            ).FirstOrDefaultAsync();


            if (executors == 0)
            {
                return NotFound();
            }

            return executors;
        }

        private bool PersonRegistrationExists(int id)
        {
            return _context.PersonRegistrations.Any(e => e.Id == id);
        }
    }
}