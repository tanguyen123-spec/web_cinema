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
        public async Task<List<PhimGioChieu>> GetPhimGioChieuByIDNgayChieu(GetPhimByIDNgayChieumodels phim)
        {
            var lichchieus = _context.Lichchieus.Where(lc => lc.NgayChieu == phim.NgayChieu).ToList();
            var danhSachPhimGioChieu = new List<PhimGioChieu>();

            var phimGioChieuGroups = lichchieus
                .Join(_context.Lichchieuphims, lc => lc.MaLichChieu, lp => lp.MaLichChieu, (lc, lp) => new { lc, lp })
                .Join(_context.Phims, lcp => lcp.lp.MaPhim, p => p.MaPhim, (lcp, p) => new { lcp.lc, p })
                .GroupBy(lcpp => lcpp.p.TenPhim);

            foreach (var phimGioChieuGroup in phimGioChieuGroups)
            {
                var tenPhim = phimGioChieuGroup.Key;
                var gioChieuList = phimGioChieuGroup.Select(lcpp => lcpp.lc.GioChieu).ToList();

                var phimGioChieu = new PhimGioChieu
                {
                    TenPhim = tenPhim,
                    GioChieu = gioChieuList
                };

                danhSachPhimGioChieu.Add(phimGioChieu);
            }

            return danhSachPhimGioChieu;
        }
    }
}