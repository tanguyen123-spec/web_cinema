﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;
using System.Data;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichChieuController : ControllerBase
    {
            private readonly ILichChieuService services;
            public LichChieuController(ILichChieuService services)
            {
                this.services = services;
            }
            [HttpGet]
        [Authorize(Roles = "Admin")]
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
         
            [HttpPost("add-by-models")]
            public async Task<IActionResult> AddLCPByModels(LichchieuModels lichchieuphim)
            {
                if (lichchieuphim == null)
                {
                    return BadRequest();
                }
                await services.CreatebyModels(lichchieuphim);
            return CreatedAtAction(nameof(GetById), new { id = lichchieuphim.MaLichChieu }, lichchieuphim);
        }

            // Endpoint for updating an existing Ctdatve entity
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(string id, Lichchieu Lichchieu)
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

