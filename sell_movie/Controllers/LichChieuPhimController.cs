using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichChieuPhimController : ControllerBase
    {
        private readonly LichChieuPhimServices services;
        public LichChieuPhimController(LichChieuPhimServices services)
        {
            this.services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lcp = await services.GetAll();
            return Ok(lcp);
        }

        // Endpoint for retrieving a specific Ctdatve entity by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var lcp = await services.GetById(id);
            return Ok(lcp);
        }

        // Endpoint for adding a new Ctdatve entity
        [HttpPost]
        public async Task<IActionResult> Add(Lichchieuphim Lichchieu)
        {
            if (Lichchieu != null)
            {
                await services.Create(Lichchieu);
            }
            return BadRequest("Đã Thêm");
        }
        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddLCPByModels(LichchieuphimModels lichchieuphim)
        {
            if (lichchieuphim == null)
            {
                return BadRequest();
            }
            await services.CreatebyModels(lichchieuphim);
            return Ok(lichchieuphim);
        }

        // Endpoint for updating an existing Ctdatve entity
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Lichchieuphim Lichchieu)
        {
            if (Lichchieu != null)
            {
                await services.Update(id, Lichchieu);
            }
            return Ok();
        }

        // Endpoint for deleting a specific Ctdatve entity by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services.Delete(id);
            return BadRequest("Đã xóa lịch chiếu phim");
        }
    }
}
