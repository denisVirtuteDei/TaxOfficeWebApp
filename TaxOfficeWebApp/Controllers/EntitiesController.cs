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
    public class EntitiesController : ControllerBase
    {
        private readonly TaxOfficeContext _context;

        public EntitiesController(TaxOfficeContext context)
        {
            _context = context;
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

        // PUT: api/Entities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(string unp, Entity entity)
        {
            if (unp != entity.Unp)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(unp))
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
