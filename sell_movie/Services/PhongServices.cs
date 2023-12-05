using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class PhongServices : MyRepository<Phong>
    {
        private readonly web_cinema3Context _context;
        public PhongServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task CustomCreate(PhongModels phong)
        {
            // Thực hiện các thay đổi cụ thể bạn muốn thêm vào trước khi gọi phương thức Create mặc định
            var Phong = new Phong
            {
                TenPhong = phong.TenPhong,
                MaPhong = phong.MaPhong,
                SoChoNgoi = phong.SoChoNgoi,
                SoHang = phong.SoHang,
                Socot = phong.Socot,
            };
            for (int hang = 1; hang <= Phong.SoHang; hang++)
            {
                for (int cot = 1; cot <= Phong.Socot; cot++)
                {
                    var tenGhe = $"{hang}-{cot}";
                    var maGhe = $"{Phong.MaPhong}-{Phong.SoChoNgoi}";
                    var ghe = new Ghe
                    {
                        MaGhe = maGhe,
                        TenGhe = tenGhe,
                    };

                    Phong.Ghes.Add(ghe);
                }
            }
            _context.Add(Phong);
            await _context.SaveChangesAsync();
        }
    }
}
