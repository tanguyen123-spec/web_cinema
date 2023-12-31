﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService services_;
        public NguoiDungController(INguoiDungService services_)
        {
            this.services_ = services_;
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await services_.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var theloai = await services_.GetById(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return Ok(theloai);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Nguoidung nguoidung)
        {
            if (nguoidung == null)
            {
                return BadRequest();
            }
            await services_.Create(nguoidung);
            return Ok();

        }
        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddNguoidungByModels(NguoidungModels nguoidung)
        {
            if (nguoidung == null)
            {
                return BadRequest();
            }
            await services_.CreatebyModels(nguoidung);
            return Ok(nguoidung);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, NguoidungModels nguoidung)
        {
            await services_.UpdateByModel(id, nguoidung);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return Ok("Ctdatve deleted successfully.");
        }
       
    }
}
