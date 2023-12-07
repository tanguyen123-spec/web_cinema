using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TtDatVeController : ControllerBase
    {
        private readonly TtDatVeServices _services;
        public TtDatVeController(TtDatVeServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctdatves = await _services.GetAll();
            return Ok(ctdatves);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ctdatve = await _services.GetById(id);
            if (ctdatve == null)
            {
                return NotFound();
            }
            return Ok(ctdatve);
        }

        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddTheloaiByModels(TtdatveModels ttdatve)
        {
            if (ttdatve == null)
            {
                return BadRequest();
            }
            await _services.CreatebyModels(ttdatve);
            return Ok(ttdatve);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Ttdatve ttdv)
        {
            if (ttdv == null)
            {
                return BadRequest();
            }
            await _services.Update(id, ttdv);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _services.Delete(id);
            return Ok("Ctdatve deleted successfully.");
        }

    }
}
