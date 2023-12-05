using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System.Threading.Tasks;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrangThaiGheController : ControllerBase
    {
        private readonly ITrangThaiGheService _trangThaiGheService;

        public TrangThaiGheController(ITrangThaiGheService trangThaiGheService)
        {
            _trangThaiGheService = trangThaiGheService;
        }

        // GET: api/TrangThaiGhe
        [HttpGet]
        public async Task<IActionResult> GetAllTrangThaiGhes()
        {
            var trangThaiGhes = await _trangThaiGheService.GetAllTrangThaiGhes();
            return Ok(trangThaiGhes);
        }

        // GET: api/TrangThaiGhe/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrangThaiGheById(string id)
        {
            var trangThaiGhe = await _trangThaiGheService.GetTrangThaiGheById(id);
            if (trangThaiGhe == null)
                return NotFound();
            return Ok(trangThaiGhe);
        }

        // POST: api/TrangThaiGhe
        [HttpPost]
        public async Task<IActionResult> CreateTrangThaiGhe(TrangThaiGheModels trangThaiGheModels)
        {
            await _trangThaiGheService.CreateTrangThaiGhe(trangThaiGheModels);
            return CreatedAtAction(nameof(GetTrangThaiGheById), new { id = trangThaiGheModels.Maghe }, trangThaiGheModels);
        }

        // PUT: api/TrangThaiGhe/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrangThaiGhe(string id, TrangThaiGheModels trangThaiGheModels)
        {
            await _trangThaiGheService.UpdateTrangThaiGhe(id, trangThaiGheModels);
            return NoContent();
        }

        // DELETE: api/TrangThaiGhe/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrangThaiGhe(string id)
        {
            await _trangThaiGheService.DeleteTrangThaiGhe(id);
            return NoContent();
        }
    }
}