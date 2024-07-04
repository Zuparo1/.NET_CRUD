using API_Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BokController : ControllerBase
    {
        private readonly BibliotekContextContext _context;

        public BokController(BibliotekContextContext context)
        {
            _context = context;
        }

        //Hente alle bøkene
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bok>>> GetBoeker()
        {
            return await _context.Bøker.ToListAsync();
        }

        //Hente en spesefik bok
        [HttpGet("{id}")]
        public async Task<ActionResult<Bok>> GetBok(int id)
        {
            var bok = await _context.Bøker.FindAsync(id);

            if (bok == null)
            {
                return NotFound();
            }

            return bok;
        }

        //Legge til ny bok
        [HttpPost]
        public async Task<ActionResult<Bok>> PostBok(Bok bok)
        {
            _context.Bøker.Add(bok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBok", new { id = bok.BokID }, bok);
        }

        //Oppdatere bok
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBok(int id, Bok bok)
        {
            if (id != bok.BokID)
            {
                return BadRequest();
            }

            _context.Entry(bok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                //Boken ekisterer
                if (_context.Bøker.Any(e => e.BokID == id))
                {
                    throw;
                }
                else
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        //Slette en bok
        [HttpDelete("{id}")]
        public async Task<ActionResult> SlettBok(int id) 
        {
            var bok = await _context.Bøker.FindAsync(id);
            if (bok == null) 
            {
                return NotFound();
            }

            _context.Bøker.Remove(bok);
            await _context.SaveChangesAsync(); 

            return NoContent();
        }
    }
}
