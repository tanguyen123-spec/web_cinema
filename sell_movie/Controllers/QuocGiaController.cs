using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sell_movie.Controllers
{
    [Route("api/quocgia")]
    [ApiController]
    public class QuocGiaController : ControllerBase
    {
        private readonly IQuocGiaService _quocGiaService;

        public QuocGiaController(IQuocGiaService quocGiaService)
        {
            _quocGiaService = quocGiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuocGiaModels>>> GetAllQuocGia()
        {
            var quocGiaList = await _quocGiaService.GetAll();
            return Ok(quocGiaList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuocGiaModels>> GetQuocGiaById(string id)
        {
            var quocGia = await _quocGiaService.GetById(id);
            if (quocGia == null)
            {
                return NotFound();
            }
            return Ok(quocGia);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuocGia(QuocGiaModels quocGia)
        {
            await _quocGiaService.Add(quocGia);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuocGia(string id, QuocGiaModels quocGia)
        {
            await _quocGiaService.Update(id, quocGia);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuocGia(string id)
        {
            await _quocGiaService.Delete(id);
            return Ok();
        }
    }
}