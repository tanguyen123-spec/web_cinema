using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetIdGheController : ControllerBase
    {
        private readonly IGetIDGheService _Service;

        public GetIdGheController(IGetIDGheService Service)
        {
            _Service = Service;
        }
        [HttpGet]
        public async Task<IActionResult> GetGheByTenPhimVaGioChieu(string tenPhim, DateTime gioChieu)
        {
            // Tạo một đối tượng GeTGhemodel từ các tham số đầu vào
            var tGhemodel = new GeTGhemodel
            {
                TenPhim = tenPhim,
                Gio = gioChieu.Hour,
                Phut = gioChieu.Minute
            };

            try
            {
                var danhSachGhe = await _Service.GetGheByTenPhimVaGioChieu(tGhemodel);

                if (danhSachGhe.Count > 0)
                {
                    return Ok(danhSachGhe); // Trả về danh sách ghế nếu tìm thấy
                }
                else
                {
                    return NotFound(); // Trả về mã 404 Not Found nếu không tìm thấy danh sách ghế
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi 500 Internal Server Error nếu có lỗi xảy ra trong quá trình xử lý
                return StatusCode(500, ex.Message);
            }
        }
    }
}
