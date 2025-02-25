using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DUAN_C5.Data;
using API_DUAN_C5.Models;

namespace API_DUAN_C5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DinersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Diner>>> GetDiners()
        {
            return await _context.Diners.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Diner>> GetDiner(int id)
        {
            var diner = await _context.Diners.FindAsync(id);
            if (diner == null) return NotFound();
            return diner;
        }

        [HttpPost]
        public async Task<ActionResult<Diner>> PostDiner(Diner diner)
        {
            diner.Id = 0;
            _context.Diners.Add(diner);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDiner), new { id = diner.Id }, diner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiner(int id, Diner diner)
        {
            if (id != diner.Id) return BadRequest();

            _context.Entry(diner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiner(int id)
        {
            var diner = await _context.Diners.FindAsync(id);
            if (diner == null) return NotFound();

            _context.Diners.Remove(diner);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
