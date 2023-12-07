using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class ThanhToanServices : MyRepository<Thanhtoan>
    {
        private readonly web_cinema3Context _context;
        public ThanhToanServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task AddAll(ThanhToanModels thanhToan )
        {
            var th = new Thanhtoan
            { 
               MaDatVe = thanhToan.MaDatVe,
               MaNhanVien = thanhToan.MaNhanVien,
                MaThanhToan = thanhToan.MaThanhToan,
                NgayThanhToan = thanhToan.NgayThanhToan,
                Phuongthucthanhtoan = thanhToan.Phuongthucthanhtoan,
            };
           _context.Add(th);
            await _context.SaveChangesAsync();

        }
    }
}
