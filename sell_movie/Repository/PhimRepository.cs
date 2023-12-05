using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using   sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace Sell_movie_ticket.Repository
{
    public class PhimRepository : IRepository<PhimModels>
    {
        private readonly web_cinema3Context _context;

        public PhimRepository(web_cinema3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhimModels>> GetAll()
        {
            var phims = await _context.Phims.ToListAsync();
            return phims.Select(phim => new PhimModels
            {
                MaPhim = phim.MaPhim,
                TenPhim = phim.TenPhim,
                Ngaykhoichieu = phim.Ngaykhoichieu,
                Mota = phim.Mota,
                Anh = phim.Anh,
                Trailer = phim.Trailer,
                MaTl = phim.MaTl,
                MaQuocGia = phim.MaQuocGia,
                Banner = phim.Banner,
                Thoiluong = phim.Thoiluong
            });
        }

        public async Task<PhimModels> GetById(string id)
        {
            var phim = await _context.Phims.FindAsync(id);
            if (phim != null)
            {
                return new PhimModels
                {
                    MaPhim = phim.MaPhim,
                    TenPhim = phim.TenPhim,
                    Ngaykhoichieu = phim.Ngaykhoichieu,
                    Mota = phim.Mota,
                    Anh = phim.Anh,
                    Trailer = phim.Trailer,
                    MaTl = phim.MaTl,
                    MaQuocGia = phim.MaQuocGia,
                    Banner = phim.Banner,
                    Thoiluong = phim.Thoiluong
                };
            }
            return null;
        }

        public async Task Create(PhimModels entity)
        {
            var phim = new Phim
            {
                MaPhim = entity.MaPhim,
                TenPhim = entity.TenPhim,
                Ngaykhoichieu = entity.Ngaykhoichieu,
                Mota = entity.Mota,
                Anh = entity.Anh,
                Trailer = entity.Trailer,
                MaTl = entity.MaTl,
                MaQuocGia = entity.MaQuocGia,
                Banner = entity.Banner,
                Thoiluong = entity.Thoiluong
            };

            _context.Phims.Add(phim);
            await _context.SaveChangesAsync();
        }

        public async Task Update(string id, PhimModels entity)
        {
            var phim = await _context.Phims.FindAsync(id);
            if (phim != null)
            {
                phim.MaPhim = entity.MaPhim;
                phim.TenPhim = entity.TenPhim;
                phim.Ngaykhoichieu = entity.Ngaykhoichieu;
                phim.Mota = entity.Mota;
                phim.Anh = entity.Anh;
                phim.Trailer = entity.Trailer;
                phim.MaTl = entity.MaTl;
                phim.MaQuocGia = entity.MaQuocGia;
                phim.Banner = entity.Banner;
                phim.Thoiluong = entity.Thoiluong;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(string id)
        {
            var phim = await _context.Phims.FindAsync(id);
            if (phim != null)
            {
                _context.Phims.Remove(phim);
                await _context.SaveChangesAsync();
            }
        }
    }
}
