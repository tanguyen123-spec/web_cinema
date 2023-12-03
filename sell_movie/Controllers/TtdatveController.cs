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
    public class TtDatVeController : ControllerBase
    {
        private readonly ITtDatVeServices _ttDatVeService;

        public TtDatVeController(ITtDatVeServices ttDatVeService)
        {
            _ttDatVeService = ttDatVeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTtDatVe()
        {
            try
            {
                var ttDatVes = await _ttDatVeService.GetAll();
                return Ok(ttDatVes);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTtDatVeById(string id)
        {
            try
            {
                var ttDatVe = await _ttDatVeService.GetById(id);
                if (ttDatVe == null)
                {
                    return NotFound();
                }
                return Ok(ttDatVe);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTtDatVe(TtdatveModels ttDatVe)
        {
            try
            {
                await _ttDatVeService.Add(ttDatVe);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTtDatVe(string id, TtdatveModels ttDatVe)
        {
            try
            {
                await _ttDatVeService.Update(id, ttDatVe);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTtDatVe(string id)
        {
            try
            {
                await _ttDatVeService.Delete(id);
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