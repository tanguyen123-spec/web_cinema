using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System.Data;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisInforController : ControllerBase
    {
        private readonly IDisInforService _disInforService;

        public DisInforController(IDisInforService disInforService)
        {
            _disInforService = disInforService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemDatVe([FromBody] DisInforModel disInfor)
        {
            if (disInfor == null)
            {
                return BadRequest();
            }

            _disInforService.ThemDatVe(disInfor);

            return Ok();
        }
        [HttpGet("MaLichPhim")]
        public IActionResult GetMaLichPhim([FromQuery] DisInforModel disInfor)
        {
            var maLichPhim = _disInforService.LayMaLichPhim(disInfor);

            if (!string.IsNullOrEmpty(maLichPhim))
            {
                return Ok(maLichPhim);
            }
            else
            {
                return NotFound("Không tìm thấy mã lịch phim cho giờ và ngày đã nhập.");
            }
        }
    }

}
