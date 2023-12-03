using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly IPhongServices _phongService;

        public PhongController(IPhongServices phongService)
        {
            _phongService = phongService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhong()
        {
            try
            {
                var phongs = await _phongService.GetAll();
                return Ok(phongs);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhongById(string id)
        {
            try
            {
                var phong = await _phongService.GetById(id);
                if (phong == null)
                {
                    return NotFound();
                }
                return Ok(phong);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPhong(PhongModels phong)
        {
            try
            {
                await _phongService.Add(phong);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhong(string id, PhongModels phong)
        {
            try
            {
                await _phongService.Update(id, phong);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhong(string id)
        {
            try
            {
                await _phongService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddGheByPhong")]
        public async Task<IActionResult> AddGheByPhong(PhongModels phong)
        {
            try
            {
                await _phongService.AddGheByPhong(phong);
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