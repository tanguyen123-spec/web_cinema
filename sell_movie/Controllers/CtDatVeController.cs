using Microsoft.AspNetCore.Mvc;
using sell_movie.Filters;
using sell_movie.Models;
using sell_movie.Services;
using System;
using System.Threading.Tasks;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MyAsyncFilterAtribute("Controller")]


    public class CtdatveController : ControllerBase
    {
        private readonly ICtdatveService _ctdatveService;

        public CtdatveController(ICtdatveService ctdatveService)
        {
            _ctdatveService = ctdatveService;
        }

        [HttpGet]
        [MyFilterAtribute("Action",-10)]
        [MyFilterResourceFilter("Action")]

        public async Task<IActionResult> GetAll()
        {
            Console.Write("The action is being executed");
            try
            {
                var ctdatves = await _ctdatveService.GetAll();
                return Ok(ctdatves);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var ctdatve = await _ctdatveService.GetById(id);
                if (ctdatve == null)
                {
                    return NotFound();
                }
                return Ok(ctdatve);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CtdatveModels ctdatve)
        {
            try
            {
                await _ctdatveService.Add(ctdatve);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CtdatveModels ctdatve)
        {
            try
            {
                await _ctdatveService.Update(id, ctdatve);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi nếu cần
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _ctdatveService.Delete(id);
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