﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;

[Route("api/[controller]")]
[ApiController]
public class PhongController : ControllerBase
{
    private readonly IPhongService _services;

    public PhongController(IPhongService services)
    {
        _services = services ?? throw new ArgumentNullException(nameof(services));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var phongs = await _services.GetAll();
        return Ok(phongs);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var phong = await _services.GetById(id);
        if (phong == null)
        {
            return BadRequest("Phòng không tồn tại!");
        }
        return Ok(phong);
    }
    [HttpPost("add-ghe")]
    public async Task<IActionResult> CreateGheByPhong(PhongModels phong)
    {
        if (phong == null)
        {
            return BadRequest();
        }    
        await _services.CustomCreate(phong);
        return Ok(phong);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(string id, Phong phong)
    {
        if (phong != null)
        {
            await _services.Update(id, phong);
            return Ok();
        }
        return BadRequest("Chưa chỉnh sửa được!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _services.Delete(id);
        return NoContent();
    }
    [HttpDelete("delete-ghe-and-phong-and-trangthaighe")]
    public async Task<IActionResult> DeleteGheAndPhong(string id)
    {
        await _services.DeleteGhe(id);
        return Ok();
    }
    [HttpGet("roomCodeByRoomName/{roomName}")]
    public async Task<IActionResult> GetRoomCodeByRoomName(string roomName)
    {
        var roomCode = await _services.GetRoomCodeByRoomName(roomName);
        if (roomCode == null)
        {
            return NotFound();
        }
        return Ok(roomCode);
    }
}
