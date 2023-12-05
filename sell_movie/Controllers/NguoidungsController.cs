using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using Sell_movie_ticket.Services;

namespace sell_movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NguoidungController : ControllerBase
    {
        private readonly INguoidungService _nguoidungService;

        public NguoidungController(INguoidungService nguoidungService)
        {
            _nguoidungService = nguoidungService;
        }

        // GET: api/Nguoidung
        [HttpGet]
        public async Task<IActionResult> GetAllNguoidungs()
        {
            var nguoidungs = await _nguoidungService.GetAllNguoidungs();
            return Ok(nguoidungs);
        }

        // GET: api/Nguoidung/{username}
        [HttpGet("{username}")]
        public async Task<IActionResult> GetNguoidungByUsername(string username)
        {
            var nguoidung = await _nguoidungService.GetNguoidungByUsername(username);
            if (nguoidung == null)
            {
                return NotFound();
            }
            return Ok(nguoidung);
        }

        // POST: api/Nguoidung
        [HttpPost]
        public async Task<IActionResult> AddNguoidung(NguoidungModels nguoidung)
        {
            await _nguoidungService.AddNguoidung(nguoidung);
            return CreatedAtAction(nameof(GetNguoidungByUsername), new { username = nguoidung.Username }, nguoidung);
        }

        // PUT: api/Nguoidung/{username}
        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateNguoidung(string username, NguoidungModels nguoidung)
        {
            if (username != nguoidung.Username)
            {
                return BadRequest();
            }

            await _nguoidungService.UpdateNguoidung(username, nguoidung);
            return NoContent();
        }

        // DELETE: api/Nguoidung/{username}
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteNguoidung(string username)
        {
            await _nguoidungService.DeleteNguoidung(username);
            return NoContent();
        }
    }
}
