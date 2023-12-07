﻿using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class GheServices : MyRepository<Ghe> 
    {
        private readonly web_cinema3Context _context;
        public GheServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task CreatebyModels(GheModels ghe)
        {
            var g = new Ghe
            {
                MaGhe = ghe.MaGhe,
                TenGhe = ghe.TenGhe,
                MaPhong = ghe.MaPhong
            };
            _context.Ghes.Add(g);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Ghe>> GetGheByMaPhongAsync(string maPhong)
        {
            return await _context.Ghes.Where(g => g.MaPhong == maPhong).ToListAsync();
        }
    }
}
