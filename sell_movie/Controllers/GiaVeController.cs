using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaveController : ControllerBase
    {
        private readonly IGiaveService _giaveService;

        public GiaveController(IGiaveService giaveService)
        {
            _giaveService = giaveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGiaveModels()
        {
            var giaveModels = await _giaveService.GetAllGiaveModels();
            return Ok(giaveModels);
        }

        [HttpGet("{maGiaVe}")]
        public async Task<IActionResult> GetGiaveModelsById(string maGiaVe)
        {
            var giaveModels = await _giaveService.GetGiaveModelsById(maGiaVe);
            if (giaveModels == null)
                return NotFound();

            return Ok(giaveModels);
        }

        [HttpPost]
        public async Task<IActionResult> AddGiaveModels([FromBody] GiaveModels giaveModels)
        {
            await _giaveService.AddGiaveModels(giaveModels);
            return Ok();
        }

        [HttpPut("{maGiaVe}")]
        public async Task<IActionResult> UpdateGiaveModels(string maGiaVe, [FromBody] GiaveModels giaveModels)
        {
            await _giaveService.UpdateGiaveModels(giaveModels);
            return Ok();
        }

        [HttpDelete("{maGiaVe}")]
        public async Task<IActionResult> DeleteGiaveModels(string maGiaVe)
        {
            await _giaveService.DeleteGiaveModels(maGiaVe);
            return Ok();
        }
    }
}