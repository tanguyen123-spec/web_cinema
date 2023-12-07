using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuocGiaController : ControllerBase
    {
        private QuocGiaServices services_;
        public QuocGiaController(QuocGiaServices services_)
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

        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddQuocGiaByModels(QuocGiaModels quocgium)
        {
            if (quocgium == null)
            {
                return BadRequest();
            }
            await services_.CreatebyModels(quocgium);
            return Ok(quocgium);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Quocgium quocgia)
        {
            if (quocgia == null)
            {
                return BadRequest();
            }
            await services_.Update(id, quocgia);
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
