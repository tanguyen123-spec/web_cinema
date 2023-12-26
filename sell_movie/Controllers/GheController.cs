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
    public class GheController : ControllerBase
    {
        private readonly IGheService services_;
        public GheController(IGheService services)
        {
            services_ = services;
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

        [HttpPost]
        public async Task<IActionResult> Add(Ghe ghe)
        {
            if (ghe == null)
            {
                return BadRequest();
            }
            await services_.Create(ghe);
            return Ok();

        }
        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddGheBymodel(GheModels g)
        {
            if (g == null)
            {
                return BadRequest();
            }
            await services_.CreatebyModels(g);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Ghe ghe)
        {
            if (ghe == null)
            {
                return BadRequest();
            }
            await services_.Update(id, ghe);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return Ok("Ctdatve deleted successfully.");
        }
        [HttpGet("phong/{maPhong}/ghe")]
        public async Task<IActionResult> GetGheByMaPhong(string maPhong)
        {
            var ghePhong = await services_.GetGheByMaPhongAsync(maPhong);
            return Ok(ghePhong);
        }
    }
}
