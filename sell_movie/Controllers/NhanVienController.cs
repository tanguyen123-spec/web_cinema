using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly NhanVienServices services_;
        public NhanVienController(NhanVienServices services_)
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
            var nhanvien = await services_.GetById(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return Ok(nhanvien);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Nhanvien nhanvien)
        {
            if (nhanvien == null)
            {
                return BadRequest();
            }
            await services_.Create(nhanvien);
            return Ok();

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Nhanvien nhanvien)
        {
            if (nhanvien == null)
            {
                return BadRequest();
            }
            await services_.Update(id, nhanvien);
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
