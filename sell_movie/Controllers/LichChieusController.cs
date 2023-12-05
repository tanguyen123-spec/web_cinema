using Microsoft.AspNetCore.Mvc;
using sell_movie.Services;
using sell_movie.Models;

namespace sell_movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LichChieusController : ControllerBase
    {
        private readonly ILichChieuService _lichChieuService;

        public LichChieusController(ILichChieuService lichChieuService)
        {
            _lichChieuService = lichChieuService;
        }

        // GET: api/LichChieus
        [HttpGet]
        public async Task<IActionResult> GetAllLichChieus()
        {
            var lichchieus = await _lichChieuService.GetAll();
            return Ok(lichchieus);
        }

        // GET: api/LichChieus/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLichChieuById(string id)
        {
            var lichchieu = await _lichChieuService.GetById(id);
            if (lichchieu == null)
            {
                return NotFound();
            }
            return Ok(lichchieu);
        }

        // POST: api/LichChieus
        [HttpPost]
        public async Task<IActionResult> AddLichChieu(LichChieuModels lichchieu)
        {
            await _lichChieuService.Add(lichchieu);
            return CreatedAtAction(nameof(GetLichChieuById), new { id = lichchieu.MaLichChieu }, lichchieu);
        }

        // PUT: api/LichChieus/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLichChieu(string id, LichChieuModels lichchieu)
        {
            if (id != lichchieu.MaLichChieu)
            {
                return BadRequest();
            }

            await _lichChieuService.Update(id, lichchieu);
            return NoContent();
        }

        // DELETE: api/LichChieus/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichChieu(string id)
        {
            await _lichChieuService.Delete(id);
            return NoContent();
        }
    }
}
