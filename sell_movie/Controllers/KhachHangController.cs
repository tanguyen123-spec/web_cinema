using Microsoft.AspNetCore.Mvc;
using sell_movie.Enities;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachhangApiController : ControllerBase
    {
        private readonly IKhachhangService _khachhangService;

        public KhachhangApiController(IKhachhangService khachhangService)
        {
            _khachhangService = khachhangService;
        }

        // GET: api/KhachhangApiController
        [HttpGet]
        public IActionResult GetAllKhachhang()
        {
            var khachhangs = _khachhangService.GetAllKhachhang();
            return Ok(khachhangs);
        }

        // GET: api/KhachhangApiController/{id}
        [HttpGet("{id}")]
        public IActionResult GetKhachhangById(string id)
        {
            var khachhang = _khachhangService.GetKhachhangById(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return Ok(khachhang);
        }

        // POST: api/KhachhangApiController
        [HttpPost]
        public IActionResult AddKhachhang(Khachhang khachhang)
        {
            _khachhangService.AddKhachhang(khachhang);
            return CreatedAtAction(nameof(GetKhachhangById), new { id = khachhang.Makhachhang }, khachhang);
        }

        // PUT: api/KhachhangApiController/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateKhachhang(string id, Khachhang khachhang)
        {
            if (id != khachhang.Makhachhang)
            {
                return BadRequest();
            }

            _khachhangService.UpdateKhachhang(khachhang);
            return NoContent();
        }

        // DELETE: api/KhachhangApiController/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteKhachhang(string id)
        {
            _khachhangService.DeleteKhachhang(id);
            return NoContent();
        }
    }
}