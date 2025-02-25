using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DUAN_C5.Data;
using API_DUAN_C5.Models;

namespace API_DUAN_C5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VouchersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Voucher>>> GetVouchers()
        {
            return await _context.Vouchers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucher(int id)
        {
            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null) return NotFound();
            return voucher;
        }

        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(Voucher voucher)
        {
            voucher.Id = 0;
            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVoucher), new { id = voucher.Id }, voucher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucher(int id, Voucher voucher)
        {
            if (id != voucher.Id) return BadRequest();

            _context.Entry(voucher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(int id)
        {
            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null) return NotFound();

            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
