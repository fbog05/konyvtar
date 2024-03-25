using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using konyvtar.Data;
using konyvtar.Models;

namespace konyvtar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolcsonzokController : ControllerBase
    {
        private readonly konyvtarContext _context;

        public KolcsonzokController(konyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Kolcsonzok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kolcsonzok>>> GetKolcsonzok()
        {
          if (_context.Kolcsonzok == null)
          {
              return NotFound();
          }
            return await _context.Kolcsonzok.ToListAsync();
        }

        // GET: api/Kolcsonzok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kolcsonzok>> GetKolcsonzok(int id)
        {
          if (_context.Kolcsonzok == null)
          {
              return NotFound();
          }
            var kolcsonzok = await _context.Kolcsonzok.FindAsync(id);

            if (kolcsonzok == null)
            {
                return NotFound();
            }

            return kolcsonzok;
        }

        // PUT: api/Kolcsonzok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKolcsonzok(int id, Kolcsonzok kolcsonzok)
        {
            if (id != kolcsonzok.Id)
            {
                return BadRequest();
            }

            _context.Entry(kolcsonzok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KolcsonzokExists(id))
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

        // POST: api/Kolcsonzok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kolcsonzok>> PostKolcsonzok(Kolcsonzok kolcsonzok)
        {
          if (_context.Kolcsonzok == null)
          {
              return Problem("Entity set 'konyvtarContext.Kolcsonzok'  is null.");
          }
            _context.Kolcsonzok.Add(kolcsonzok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKolcsonzok", new { id = kolcsonzok.Id }, kolcsonzok);
        }

        // DELETE: api/Kolcsonzok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKolcsonzok(int id)
        {
            if (_context.Kolcsonzok == null)
            {
                return NotFound();
            }
            var kolcsonzok = await _context.Kolcsonzok.FindAsync(id);
            if (kolcsonzok == null)
            {
                return NotFound();
            }

            _context.Kolcsonzok.Remove(kolcsonzok);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KolcsonzokExists(int id)
        {
            return (_context.Kolcsonzok?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
