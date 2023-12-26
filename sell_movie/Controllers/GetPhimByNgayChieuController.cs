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
    public class GetPhimByNgayChieuController : ControllerBase
    {
        private readonly IGetPhimByIdNgayChieuService _service;
        public GetPhimByNgayChieuController(IGetPhimByIdNgayChieuService service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<PhimGioChieu>>> GetPhimGioChieuByNgayChieu(DateTime ngayChieu)
        {
            var phim = new GetPhimByIDNgayChieumodels
            {
                NgayChieu = ngayChieu
            };

            var danhSachPhimGioChieu = await _service.GetPhimGioChieuByIDNgayChieu(phim);

            if (danhSachPhimGioChieu.Count == 0)
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy dữ liệu
            }

            return danhSachPhimGioChieu;
        }
    }
}
