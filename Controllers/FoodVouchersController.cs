using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DUAN_C5.Data;
using API_DUAN_C5.Models;

namespace API_DUAN_C5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodVouchersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FoodVouchersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FoodVoucher>>> GetFoodVouchers()
        {
            return await _context.FoodVouchers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodVoucher>> GetFoodVoucher(int id)
        {
            var fv = await _context.FoodVouchers.FindAsync(id);
            if (fv == null) return NotFound();
            return fv;
        }

        [HttpPost]
        public async Task<ActionResult<FoodVoucher>> PostFoodVoucher(FoodVoucher fv)
        {
            fv.Id = 0;
            _context.FoodVouchers.Add(fv);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFoodVoucher), new { id = fv.Id }, fv);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodVoucher(int id, FoodVoucher fv)
        {
            if (id != fv.Id) return BadRequest();

            _context.Entry(fv).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodVoucher(int id)
        {
            var fv = await _context.FoodVouchers.FindAsync(id);
            if (fv == null) return NotFound();

            _context.FoodVouchers.Remove(fv);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
