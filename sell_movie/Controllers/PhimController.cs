using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhimController : ControllerBase
    {
        private readonly PhimServices services_;
        public PhimController(PhimServices services_)
        {
            this.services_ = services_;
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
            var theloai = await services_.GetById(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return Ok(theloai);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Phim phim)
        {
            if (phim == null)
            {
                return BadRequest();
            }
            await services_.Create(phim);
            return Ok();

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Phim phim)
        {
            if (phim == null)
            {
                return BadRequest();
            }
            await services_.Update(id, phim);
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
