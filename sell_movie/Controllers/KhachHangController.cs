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
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService services_;
        public KhachHangController(IKhachHangService services_)
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

        [HttpPost]
        public async Task<IActionResult> Add(Khachhang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await services_.Create(khachhang);
            return Ok();

        }
        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddByModels(KhachhangModels khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }    
            await services_.AddByModels(khachhang);
            return Ok(khachhang);
        }    


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Khachhang khachhang)
        {
            if (khachhang == null)
            {
                return BadRequest();
            }
            await services_.Update(id,  khachhang);
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
