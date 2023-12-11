using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class GetPhimByIDNgayChieuService : MyRepository<GetPhimByIDNgayChieumodels>
    {
        private readonly web_cinema3Context _context;
        public GetPhimByIDNgayChieuService(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task<List<TimeSpan>> GetGioChieuByNgayChieu(DateTime ngayChieu)
        {
            var gioChieu = await _context.Lichchieus
                .Where(lc => lc.NgayChieu == ngayChieu)
                .Select(lc => lc.GioChieu)
                .ToListAsync();

            return gioChieu;
        }
        public async Task<string> GetPhimByIDNgayChieu(GetPhimByIDNgayChieumodels phim)
        {
            // Truy vấn bảng Lichchieus để lấy mã lịch chiếu dựa trên thông tin giờ chiếu và ngày chiếu
            var lichchieu = _context.Lichchieus.FirstOrDefault(lc =>
                lc.NgayChieu == phim.NgayChieu);
            if (lichchieu != null)
            {
                var lichchieuPhim = _context.Lichchieuphims.FirstOrDefault(lp =>
                    lp.MaLichChieu == lichchieu.MaLichChieu);

                if (lichchieuPhim != null)
                {
                    var maPhim = lichchieuPhim.MaPhim;
                    var tenPhim = _context.Phims.FirstOrDefault(p => p.MaPhim == maPhim)?.TenPhim;

                    if (!string.IsNullOrEmpty(tenPhim))
                    {
                        return tenPhim;
                    }
                }
            }

            return null; // Trả về null nếu không tìm thấy tên phim
        }
    }
}
