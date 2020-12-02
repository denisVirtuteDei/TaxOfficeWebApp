using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxOfficeWebApp.Models;

namespace TaxOfficeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayedTaxesController : ControllerBase
    {
        private readonly TaxOfficeContext _context;

        public PayedTaxesController(TaxOfficeContext context)
        {
            _context = context;
        }

        // GET: api/PayedTaxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayedTaxes>>> GetPayedTaxes()
        {
            return await _context.PayedTaxes.ToListAsync();
        }

        // GET: api/PayedTaxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayedTaxes>> GetPayedTaxes(int id)
        {
            var payedTaxes = await _context.PayedTaxes.FindAsync(id);

            if (payedTaxes == null)
            {
                return NotFound();
            }

            return payedTaxes;
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<PayedTaxes>> DeletePayedTaxes(int id)
        {
            var payedTaxes = await _context.PayedTaxes.FindAsync(id);
            if (payedTaxes == null)
            {
                return NotFound();
            }

            _context.PayedTaxes.Remove(payedTaxes);
            await _context.SaveChangesAsync();

            return payedTaxes;
        }

        private bool PayedTaxesExists(int id)
        {
            return _context.PayedTaxes.Any(e => e.Id == id);
        }
    }
}
