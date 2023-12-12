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

        public async Task<List<GheWithTrangThaiModel>> GetGheByTenPhimVaGioChieu(GeTGhemodel tGhemodel)
        {
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

                        // Lấy danh sách mã ghế trong bảng trạng thái ghế
                        var danhSachMaGheTrangThai1 = context_.Trangthaighes
                            .Where(tt => tt.MaPhong == maPhong && tt.TrangThai == 1)
                            .Select(tt => tt.Maghe)
                            .ToList();

                        // Lấy danh sách ghế của phòng
                        var danhSachGhe = context_.Ghes.Where(g => g.MaPhong == maPhong).ToList();

                        // Lấy số hàng và số cột từ đối tượng phong
                        var soHang = phong.SoHang;
                        var soCot = phong.Socot;

                        // Khởi tạo danh sách ghế kèm trạng thái
                        var danhSachGheWithTrangThai = new List<GheWithTrangThaiModel>();

                        // Lấy tên phòng từ mã phòng
                        var tenPhong = phong.TenPhong;

                        // Duyệt qua danh sách ghế và kiểm tra trạng thái
                        foreach (var ghe in danhSachGhe)
                        {
                            var gheWithTrangThaiModel = new GheWithTrangThaiModel
                            {
                                TenPhong = tenPhong,
                                SoHang = soHang,
                                Socot = soCot,
                                Ghe = ghe,
                                TrangThai = danhSachMaGheTrangThai1.Contains(ghe.MaGhe) ? 1 : 0
                            };

                            danhSachGheWithTrangThai.Add(gheWithTrangThaiModel);
                        }

                        return danhSachGheWithTrangThai;
                    }
                }
            }

            return new List<GheWithTrangThaiModel>(); // Trả về danh sách ghế mặc định
        }
    }
}
