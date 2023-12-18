using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaVeController : ControllerBase
    {
        private readonly IGiaVeService services_;
        public GiaVeController(IGiaVeService services)
        {
            services_ = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await services_.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var giave = await services_.GetById(id);
            if (giave == null)
            {
                return NotFound();
            }
            return Ok(giave);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Giave giave)
        {
            if (giave == null)
            {
                return BadRequest();
            }
            await services_.Create(giave);
            return Ok();

        }
        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddGiaveBymodel(GiaveModels giave)
        {
            if (giave == null)
            {
                return BadRequest();
            }
            await services_.CreatebyModels(giave);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Giave giave)
        {
            if (giave == null)
            {
                return BadRequest();
            }
            await services_.Update(id, giave);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return Ok("Ctdatve deleted successfully.");
        }
    }
}
