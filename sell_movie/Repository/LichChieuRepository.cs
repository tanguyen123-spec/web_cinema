using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;


namespace sell_movie.Repository
{
    public class LichChieuRepository : IRepository<LichChieuModels>
    {
        private readonly web_cinema3Context _context;

        public LichChieuRepository(web_cinema3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LichChieuModels>> GetAll()
        {
            var lichchieus = await _context.Lichchieus.ToListAsync();
            return lichchieus.Select(lichchieu => new LichChieuModels
            {
                MaLichChieu = lichchieu.MaLichChieu,
                NgayChieu = lichchieu.NgayChieu,

                // Chuyển đổi TimeSpan thành giờ và phút
                GioChieuHour = lichchieu.GioChieu.Hours,
                GioChieuMinute = lichchieu.GioChieu.Minutes
            });
        }

        public async Task<LichChieuModels> GetById(string id)
        {
            var lichchieu = await _context.Lichchieus.FindAsync(id);
            if (lichchieu != null)
            {
                return new LichChieuModels
                {
                    MaLichChieu = lichchieu.MaLichChieu,
                    NgayChieu = lichchieu.NgayChieu,

                    // Chuyển đổi TimeSpan thành giờ và phút
                    GioChieuHour = lichchieu.GioChieu.Hours,
                    GioChieuMinute = lichchieu.GioChieu.Minutes
                };
            }
            return null;
        }

        public async Task Create(LichChieuModels entity)
        {
            var lichchieu = new Lichchieu
            {
                MaLichChieu = entity.MaLichChieu,
                NgayChieu = entity.NgayChieu,

                // Tạo TimeSpan từ giờ và phút
                GioChieu = new TimeSpan(entity.GioChieuHour, entity.GioChieuMinute, 0)
            };

            _context.Lichchieus.Add(lichchieu);
            await _context.SaveChangesAsync();
        }

        public async Task Update(string id, LichChieuModels entity)
        {
            var lichchieu = await _context.Lichchieus.FindAsync(id);
            if (lichchieu != null)
            {
                lichchieu.MaLichChieu = entity.MaLichChieu;
                lichchieu.NgayChieu = entity.NgayChieu;

                // Cập nhật TimeSpan từ giờ và phút mới
                lichchieu.GioChieu = new TimeSpan(entity.GioChieuHour, entity.GioChieuMinute, 0);

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(string id)
        {
            var lichchieu = await _context.Lichchieus.FindAsync(id);
            if (lichchieu != null)
            {
                _context.Lichchieus.Remove(lichchieu);
                await _context.SaveChangesAsync();
            }
        }
    }
}
