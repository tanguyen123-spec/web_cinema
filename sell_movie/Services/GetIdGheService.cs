using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class GetIdGheService : MyRepository<GeTGhemodel>
    {
        private readonly web_cinema3Context context_;

        public GetIdGheService(web_cinema3Context context) : base(context)
        {
            context_ = context;
        }
        public async Task<List<Ghe>> GetGheByTenPhimVaGioChieu(GeTGhemodel tGhemodel)
        {
            // Truy vấn bảng Lichchieus để lấy mã lịch chiếu dựa trên thông tin giờ chiếu và ngày chiếu
            var lichchieu = context_.Lichchieus.FirstOrDefault(lc =>
                lc.GioChieu == new TimeSpan(tGhemodel.Gio, tGhemodel.Phut, 0));
            if (lichchieu != null)
            {
                var lichchieuPhim = context_.Lichchieuphims.FirstOrDefault(lp =>
                    lp.MaLichChieu == lichchieu.MaLichChieu && lp.MaPhimNavigation.TenPhim == tGhemodel.TenPhim);
                if (lichchieuPhim != null)
                {
                    var maPhong = lichchieuPhim.MaPhong;

                    var phong = context_.Phongs.FirstOrDefault(p => p.MaPhong == maPhong);
                    if (phong != null)
                    {
                        var maPhongGhe = phong.MaPhong;

                        var danhSachGhe = context_.Ghes.Where(g => g.MaPhong == maPhong).ToList();
                        return danhSachGhe;
                    }
                }
            }

            return new List<Ghe>(); // Trả về danh sách ghế mặc định
        }
    }
}
