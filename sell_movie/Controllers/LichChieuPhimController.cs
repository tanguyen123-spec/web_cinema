using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System;
using System.Threading.Tasks;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichChieuPhimController : ControllerBase
    {
        private readonly ILichChieuPhimServices _lichChieuPhimServices;

        public LichChieuPhimController(ILichChieuPhimServices lichChieuPhimServices)
        {
            _lichChieuPhimServices = lichChieuPhimServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lichChieuPhims = await _lichChieuPhimServices.GetAll();
                return Ok(lichChieuPhims);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var lichChieuPhim = await _lichChieuPhimServices.GetById(id);
                if (lichChieuPhim == null)
                {
                    return NotFound();
                }
                return Ok(lichChieuPhim);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(LichchieuphimModels lichChieuPhim)
        {
            try
            {
                await _lichChieuPhimServices.Add(lichChieuPhim);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, LichchieuphimModels lichChieuPhim)
        {
            try
            {
                await _lichChieuPhimServices.Update(id, lichChieuPhim);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _lichChieuPhimServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }
    }
}