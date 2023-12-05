using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;


namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhtoanController : ControllerBase
    {
        private readonly IThanhtoanService _thanhtoanService;

        public ThanhtoanController(IThanhtoanService thanhtoanService)
        {
            _thanhtoanService = thanhtoanService;
        }

        // GET: api/Thanhtoan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThanhToanModels>>> GetAllThanhtoanModels()
        {
            var thanhtoanModels = await _thanhtoanService.GetAllThanhtoanModels();
            return Ok(thanhtoanModels);
        }

        // GET: api/Thanhtoan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanhToanModels>> GetThanhtoanModelsById(int id)
        {
            var thanhtoanModels = await _thanhtoanService.GetThanhtoanModelsById(id);
            if (thanhtoanModels == null)
            {
                return NotFound();
            }
            return Ok(thanhtoanModels);
        }

        // POST: api/Thanhtoan
        [HttpPost]
        public async Task<IActionResult> AddThanhtoanModels(ThanhToanModels thanhtoanModels)
        {
            await _thanhtoanService.AddThanhtoanModels(thanhtoanModels);
            return Ok();
        }

        // PUT: api/Thanhtoan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateThanhtoanModels(string id, ThanhToanModels thanhtoanModels)
        {
            if (id != thanhtoanModels.MaThanhToan)
            {
                return BadRequest();
            }
            await _thanhtoanService.UpdateThanhtoanModels(thanhtoanModels);
            return Ok();
        }

        // DELETE: api/Thanhtoan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanhtoanModels(int id)
        {
            await _thanhtoanService.DeleteThanhtoanModels(id);
            return Ok();
        }
    }
}