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
    public class EconomicActivityTypesController : ControllerBase
    {
        private readonly TaxOfficeContext _context;

        public EconomicActivityTypesController(TaxOfficeContext context)
        {
            _context = context;
        }

        // GET: api/EconomicActivityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EconomicActivityTypes>>> GetEconomicActivityTypes()
        {
            return await _context.EconomicActivityTypes.ToListAsync();
        }

        // GET: api/EconomicActivityTypes/5
        [HttpGet("{ncea_id}")]
        public async Task<ActionResult<EconomicActivityTypes>> GetEconomicActivityType(int ncea_id)
        {
            var ncea = await _context.EconomicActivityTypes.FindAsync(ncea_id);

            if (ncea == null)
            {
                return NotFound();
            }

            return ncea;
        }

        // PUT: api/EconomicActivityTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{ncea_id}")]
        public async Task<IActionResult> PutEconomicActivityTypes(int ncea_id, EconomicActivityTypes _ncea)
        {
            if (ncea_id != _ncea.Ncea)
            {
                return BadRequest();
            }

            _context.Entry(_ncea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EconomicActivityTypesExists(ncea_id))
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

        // POST: api/EconomicActivityTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EconomicActivityTypes>> PostEconomicActivityTypes(EconomicActivityTypes ncea)
        {
            _context.EconomicActivityTypes.Add(ncea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EconomicActivityTypesExists(ncea.Ncea))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEconomicActivityTypes", new { Ncea = ncea.Ncea }, ncea);
        }

        // DELETE: api/EconomicActivityTypes/5
        [HttpDelete("{ncea_id}")]
        public async Task<ActionResult<EconomicActivityTypes>> DeleteEconomicActivityTypes(int ncea_id)
        {
            var ncea = await _context.EconomicActivityTypes.FindAsync(ncea_id);
            if (ncea == null)
            {
                return NotFound();
            }

            _context.EconomicActivityTypes.Remove(ncea);
            await _context.SaveChangesAsync();

            return ncea;
        }

        private bool EconomicActivityTypesExists(int id)
        {
            return _context.EconomicActivityTypes.Any(e => e.Ncea == id);
        }
    }
}
