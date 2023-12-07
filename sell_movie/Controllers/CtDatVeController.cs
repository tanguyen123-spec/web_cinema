using Microsoft.AspNetCore.Mvc;
using sell_movie.Models;
using sell_movie.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sell_movie.Entities;

namespace sell_movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CtdatveController : ControllerBase
    {
        private readonly CtdatveService _ctdatveService;

        public CtdatveController(CtdatveService ctdatveService)
        {
            _ctdatveService = ctdatveService;
        }

        // Endpoint for retrieving all Ctdatve entities
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctdatves = await _ctdatveService.GetAll();
            return Ok(ctdatves);
        }

        // Endpoint for retrieving a specific Ctdatve entity by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ctdatve = await _ctdatveService.GetById(id);
            if (ctdatve == null)
            {
                return NotFound();
            }
            return Ok(ctdatve);
        }

        // Endpoint for adding a new Ctdatve entity
        [HttpPost]
        public async Task<IActionResult> Add(Ctdatve ctdatveentiti)
        {
            if(ctdatveentiti == null)
            {
                return BadRequest();
            }
            await _ctdatveService.Create(ctdatveentiti);
            return Ok();
            
        }

        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddCtBymodel(CtdatveModels ct)
        {
            if (ct == null)
            {
                return BadRequest();
            }
            await _ctdatveService.CreatebyModels(ct);
            return Ok();
        }
        // Endpoint for updating an existing Ctdatve entity
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id,  Ctdatve ctDatve)
        {
            if (ctDatve == null)
            {
                return BadRequest();
            }
            await _ctdatveService.Update(id, ctDatve);
            return Ok();
        }

        // Endpoint for deleting a specific Ctdatve entity by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ctdatveService.Delete(id);
            return Ok("Ctdatve deleted successfully.");
        }
    }
}