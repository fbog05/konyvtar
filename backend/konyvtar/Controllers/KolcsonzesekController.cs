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
    public class KolcsonzesekController : ControllerBase
    {
        private readonly konyvtarContext _context;

        public KolcsonzesekController(konyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Kolcsonzesek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kolcsonzesek>>> GetKolcsonzesek()
        {
          if (_context.Kolcsonzesek == null)
          {
              return NotFound();
          }
            return await _context.Kolcsonzesek.ToListAsync();
        }

        // GET: api/Kolcsonzesek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kolcsonzesek>> GetKolcsonzesek(int id)
        {
          if (_context.Kolcsonzesek == null)
          {
              return NotFound();
          }
            var kolcsonzesek = await _context.Kolcsonzesek.FindAsync(id);

            if (kolcsonzesek == null)
            {
                return NotFound();
            }

            return kolcsonzesek;
        }

        // PUT: api/Kolcsonzesek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKolcsonzesek(int id, Kolcsonzesek kolcsonzesek)
        {
            if (id != kolcsonzesek.Id)
            {
                return BadRequest();
            }

            _context.Entry(kolcsonzesek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KolcsonzesekExists(id))
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

        // POST: api/Kolcsonzesek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kolcsonzesek>> PostKolcsonzesek(Kolcsonzesek kolcsonzesek)
        {
          if (_context.Kolcsonzesek == null)
          {
              return Problem("Entity set 'konyvtarContext.Kolcsonzesek'  is null.");
          }
            _context.Kolcsonzesek.Add(kolcsonzesek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKolcsonzesek", new { id = kolcsonzesek.Id }, kolcsonzesek);
        }

        // DELETE: api/Kolcsonzesek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKolcsonzesek(int id)
        {
            if (_context.Kolcsonzesek == null)
            {
                return NotFound();
            }
            var kolcsonzesek = await _context.Kolcsonzesek.FindAsync(id);
            if (kolcsonzesek == null)
            {
                return NotFound();
            }

            _context.Kolcsonzesek.Remove(kolcsonzesek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KolcsonzesekExists(int id)
        {
            return (_context.Kolcsonzesek?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
