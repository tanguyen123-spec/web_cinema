using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : ControllerBase
    {
        private TheLoaiServices services_;
        public TheLoaiController(TheLoaiServices services)
        {
            services_ = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //getall2 in service
            var result = await services_.GetAll2();

            if (result == null || !result.Any())
            {
                return BadRequest("Không tìm thấy!");
            }

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
        public async Task<IActionResult> AddTheloaiByModels(TheloaiModels theloai)
        {
            if (theloai == null)
            {
                return BadRequest();
            }
            await services_.CreatebyModels(theloai);
            return Ok(theloai);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Theloai theloai)
        {
            if (theloai == null)
            {
                return BadRequest();
            }
            await services_.Update(id, theloai);
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
