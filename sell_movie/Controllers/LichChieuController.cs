using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System;
using System.Collections.Generic;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichchieuController : ControllerBase
    {
        private readonly ILichchieuService _lichchieuService;

        public LichchieuController(ILichchieuService lichchieuService)
        {
            _lichchieuService = lichchieuService;
        }

        [HttpGet]
        public IActionResult GetAllLichchieu()
        {
            try
            {
                var lichchieus = _lichchieuService.GetAllLichchieu();
                return Ok(lichchieus);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLichchieuById(string id)
        {
            try
            {
                var lichchieu = _lichchieuService.GetLichchieuById(id);
                if (lichchieu == null)
                {
                    return NotFound();
                }
                return Ok(lichchieu);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddLichchieu(LichchieuModels lichchieu)
        {
            try
            {
                _lichchieuService.AddLichchieu(lichchieu);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateLichchieu(LichchieuModels lichchieu)
        {
            try
            {
                _lichchieuService.UpdateLichchieu(lichchieu);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLichchieu(string id)
        {
            try
            {
                _lichchieuService.DeleteLichchieu(id);
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