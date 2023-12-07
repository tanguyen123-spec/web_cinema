using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class TrangThaiGheServices : MyRepository<Trangthaighe>
    {
        private readonly web_cinema3Context _context;
        public TrangThaiGheServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task addTTGbyModels(TrangThaiGheModels trangThai)
        {
            var Ttg = new Trangthaighe
            {
                Maghe = trangThai.Maghe,
                MaPhong = trangThai.MaPhong,
                MaLichChieu = trangThai.MaLichChieu,
                TrangThai = trangThai.TrangThai,
            };
            _context.Add(Ttg);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrangThaiGheModels>> Getall2()
        {
            var ttg = await _context.Trangthaighes.ToListAsync();
            return ttg.Select(trangthai => new TrangThaiGheModels 
            { 
                Maghe = trangthai.Maghe,
                MaLichChieu = trangthai.MaLichChieu,
                MaPhong = trangthai.MaPhong,
                TrangThai = trangthai.TrangThai,
            });

        }
    }
}
