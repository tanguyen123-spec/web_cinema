using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrangThaiGheController : ControllerBase
    {
        private readonly ITrangThaiGheService _services;
        public TrangThaiGheController(ITrangThaiGheService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //getall2 in service
            var result = await _services.Getall2();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var theloai = await _services.GetById(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return Ok(theloai);
        }

    

        [HttpPost("by-models")]
        public async Task<IActionResult> Addbymodels(TrangThaiGheModels trangthaiGhe)
        {
            if (trangthaiGhe == null)
            {
                return BadRequest();
            }
            await _services.addTTGbyModels(trangthaiGhe);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Trangthaighe trangthai)
        {
            if (trangthai == null)
            {
                return BadRequest();
            }
            await _services.Update(id, trangthai);
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
