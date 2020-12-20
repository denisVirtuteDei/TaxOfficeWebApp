using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TaxOfficeWebApp.Models;

namespace TaxOfficeWebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin, employee, user")]
    [ApiController]
    public class BankCheckController : ControllerBase
    {
        private readonly TaxOfficeContext _context;

        public BankCheckController(TaxOfficeContext context)
        {
            _context = context;
        }

        // GET: api/BankCheck

   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankChecks>>> GetBankChecks()
        {
            return await _context.BankChecks.ToListAsync();
        }

        // GET: api/BankCheck/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankChecks>> GetBankChecks(int id)
        {
            var bankChecks = await _context.BankChecks.FindAsync(id);

            if (bankChecks == null)
            {
                return NotFound();
            }

            return bankChecks;
        }



        // PUT: api/BankCheck/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankChecks(int id, BankChecks bankChecks)
        {
            if (id != bankChecks.Id)
            {
                return BadRequest();
            }

            //bankChecks.Id = id;

            _context.Entry(bankChecks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankChecksExists(id))
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

        // POST: api/BankCheck
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BankChecks>> PostBankChecks([FromBody]JObject data)
        {
            BankChecks bankChecks = data["bankCheck"].ToObject<BankChecks>();
            string unp = data["unp"].ToObject<string>();

            var check = await (
                from u in _context.Persons
                join e in _context.PersonRegistrations on u.Id equals e.FkPerson
                where (u.FkEntityPersonUnp == unp || u.FkIndividualPersonUnp == unp || u.FkSelfEmployedPersonUnp == unp)
                select e.Id
            ).FirstOrDefaultAsync();

            if(check == 0)
            {
                return NotFound();
            }

            bankChecks.FkRegPerson = check;

            _context.BankChecks.Add(bankChecks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankChecks", new { id = bankChecks.Id }, bankChecks);
        }

        // DELETE: api/BankCheck/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BankChecks>> DeleteBankChecks(int id)
        {
            var bankChecks = await _context.BankChecks.FindAsync(id);
            if (bankChecks == null)
            {
                return NotFound();
            }

            _context.BankChecks.Remove(bankChecks);
            await _context.SaveChangesAsync();

            return bankChecks;
        }

        private bool BankChecksExists(int id)
        {
            return _context.BankChecks.Any(e => e.Id == id);
        }
    }
}
