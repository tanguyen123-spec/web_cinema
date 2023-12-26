using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CtdatveController : ControllerBase
    {
        private readonly ICtDatVeService _ctDatVeService;

        public CtdatveController(ICtDatVeService ctDatVeService)
        {
            _ctDatVeService = ctDatVeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctdatves = await _ctDatVeService.GetAll();
            return Ok(ctdatves);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ctdatve = await _ctDatVeService.GetById(id);
            if (ctdatve == null)
            {
                return NotFound();
            }
            return Ok(ctdatve);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CtdatveModels ctdatve)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ctDatVeService.CreatebyModels(ctdatve);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Ctdatve entity)
        {
            await _ctDatVeService.Update(id, entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ctDatVeService.Delete(id);
            return Ok();
        }
        [HttpGet("{maDatVe}")]
        public async Task<ActionResult<CtdatveDtocs>> GetByMaDatVe(int maDatVe)
        {
            var ctdatveDto = await _ctDatVeService.GetByMaDatVe(maDatVe);

            if (ctdatveDto == null)
            {
                return NotFound();
            }

            return ctdatveDto;
        }
    }
}
