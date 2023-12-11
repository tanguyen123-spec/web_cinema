using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPhimByNgayChieuController : ControllerBase
    {
        private readonly GetPhimByIDNgayChieuService _service;
        public GetPhimByNgayChieuController(GetPhimByIDNgayChieuService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime ngayChieu)
        {
            var phim = new GetPhimByIDNgayChieumodels
            {
                NgayChieu = ngayChieu
            };

            var tenPhim = await _service.GetPhimByIDNgayChieu(phim);

            if (!string.IsNullOrEmpty(tenPhim))
            {
                var phimGioChieu = await _service.GetGioChieuByNgayChieu(ngayChieu);

                return Ok(new { TenPhim = tenPhim, GioChieu = phimGioChieu });
            }

            return NotFound();
        }
    }
}
