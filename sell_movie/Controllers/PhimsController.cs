using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhimsController : ControllerBase
    {
        private readonly IPhimService _phimService;

        public PhimsController(IPhimService phimService)
        {
            _phimService = phimService;
        }

        // GET: api/Phims
        [HttpGet]
        public async Task<IActionResult> GetAllPhims()
        {
            var phims = await _phimService.GetAll();
            return Ok(phims);
        }

        // GET: api/Phims/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhimById(string id)
        {
            var phim = await _phimService.GetById(id);
            if (phim == null)
            {
                return NotFound();
            }
            return Ok(phim);
        }

        // POST: api/Phims
        [HttpPost]
        public async Task<IActionResult> AddPhim(PhimModels phim)
        {
            await _phimService.Add(phim);
            return CreatedAtAction(nameof(GetPhimById), new { id = phim.MaPhim }, phim);
        }

        // PUT: api/Phims/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhim(string id, PhimModels phim)
        {
            if (id != phim.MaPhim)
            {
                return BadRequest();
            }

            await _phimService.Update(id, phim);
            return NoContent();
        }

        // DELETE: api/Phims/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhim(string id)
        {
            await _phimService.Delete(id);
            return NoContent();
        }
    }
}
