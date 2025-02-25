using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_DUAN_C5.Data;
using API_DUAN_C5.Models;

namespace API_DUAN_C5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserInfosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserInfo>>> GetUserInfos()
        {
            return await _context.UserInfos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {
            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null) return NotFound();
            return userInfo;
        }

        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {
            userInfo.Id = 0;
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserInfo), new { id = userInfo.Id }, userInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInfo userInfo)
        {
            if (id != userInfo.Id) return BadRequest();

            _context.Entry(userInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null) return NotFound();

            _context.UserInfos.Remove(userInfo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
