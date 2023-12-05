using Microsoft.AspNetCore.Mvc;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Services;


namespace sell_movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhanviensController : ControllerBase
    {
        private readonly INhanvienService _nhanvienService;

        public NhanviensController(INhanvienService nhanvienService)
        {
            _nhanvienService = nhanvienService;
        }

        // GET: api/Nhanviens
        [HttpGet]
        public async Task<IActionResult> GetAllNhanviens()
        {
            var nhanviens = await _nhanvienService.GetAll();
            return Ok(nhanviens);
        }

        // GET: api/Nhanviens/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhanvienById(string id)
        {
            var nhanvien = await _nhanvienService.GetById(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return Ok(nhanvien);
        }

        // POST: api/Nhanviens
        [HttpPost]
        public async Task<IActionResult> AddNhanvien(NhanvienModels nhanvien)
        {
            await _nhanvienService.Add(nhanvien);
            return CreatedAtAction(nameof(GetNhanvienById), new { id = nhanvien.MaNhanVien }, nhanvien);
        }

        // PUT: api/Nhanviens/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhanvien(string id, NhanvienModels nhanvien)
        {
            if (id != nhanvien.MaNhanVien)
            {
                return BadRequest();
            }

            await _nhanvienService.Update(id, nhanvien);
            return NoContent();
        }

        // DELETE: api/Nhanviens/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanvien(string id)
        {
            await _nhanvienService.Delete(id);
            return NoContent();
        }
    }
}
