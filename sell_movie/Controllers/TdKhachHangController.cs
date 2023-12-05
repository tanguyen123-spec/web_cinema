using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System;
using System.Threading.Tasks;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TdKhachHangController : ControllerBase
    {
        private readonly ITdKhachHangService _tdKhachHangService;

        public TdKhachHangController(ITdKhachHangService tdKhachHangService)
        {
            _tdKhachHangService = tdKhachHangService;
        }

        // GET: api/TdKhachHang
        [HttpGet]
        public async Task<IActionResult> GetAllTdKhachHangs()
        {
            var tdKhachHangs = await _tdKhachHangService.GetAllTdKhachHangs();
            return Ok(tdKhachHangs);
        }

        // GET: api/TdKhachHang/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTdKhachHangById(string id)
        {
            var tdKhachHang = await _tdKhachHangService.GetTdKhachHangById(id);
            if (tdKhachHang == null)
                return NotFound();
            return Ok(tdKhachHang);
        }

        // POST: api/TdKhachHang
        [HttpPost]
        public async Task<IActionResult> CreateTdKhachHang(TdKhachHangModels tdKhachHangModels)
        {
            try
            {
                await _tdKhachHangService.CreateTdKhachHang(tdKhachHangModels);
                return CreatedAtAction(nameof(GetTdKhachHangById), new { id = tdKhachHangModels.Makhachhang }, tdKhachHangModels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/TdKhachHang/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTdKhachHang(string id, TdKhachHangModels tdKhachHangModels)
        {
            try
            {
                await _tdKhachHangService.UpdateTdKhachHang(id, tdKhachHangModels);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/TdKhachHang/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTdKhachHang(string id)
        {
            try
            {
                await _tdKhachHangService.DeleteTdKhachHang(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}