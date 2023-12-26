using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;
using System.Data;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhToanController : ControllerBase
    {
        private readonly IThanhToanService services_;
        public ThanhToanController(IThanhToanService services_)
        {
            this.services_ = services_;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> AddThanhToanByModels(ThanhToanModels thanhtoan)
        {
            if (thanhtoan == null)
            {
                return BadRequest();
            }
            await services_.AddAll(thanhtoan);
            return Ok(thanhtoan);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Thanhtoan thanhtoan)
        {
            if (thanhtoan == null)
            {
                return BadRequest();
            }
            await services_.Update(id, thanhtoan);
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
