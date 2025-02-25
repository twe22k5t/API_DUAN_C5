using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DUAN_C5.Data;
using API_DUAN_C5.Models;

namespace API_DUAN_C5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetails>>> GetOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetail(int id)
        {
            var od = await _context.OrderDetails.FindAsync(id);
            if (od == null) return NotFound();
            return od;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostOrderDetail(OrderDetails od)
        {
            od.Id = 0;
            _context.OrderDetails.Add(od);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderDetail), new { id = od.Id }, od);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetails od)
        {
            if (id != od.Id) return BadRequest();

            _context.Entry(od).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var od = await _context.OrderDetails.FindAsync(id);
            if (od == null) return NotFound();

            _context.OrderDetails.Remove(od);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
