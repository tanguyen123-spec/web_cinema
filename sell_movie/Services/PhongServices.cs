using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
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
                    var maGhe = $"{Phong.MaPhong}-{hang}-{cot}";
                    var ghe = new Ghe
                    {
                        MaGhe = maGhe,
                        TenGhe = tenGhe,
                    };
                    Phong.Ghes.Add(ghe);
                }
            }

            foreach (var ghe in Phong.Ghes)
            {
                var ttg = new Trangthaighe
                {
                    Maghe = ghe.MaGhe,
                    MaPhong = Phong.MaPhong,
                    TrangThai = 1,
                    MaLichChieu = "LC001"
                };
                _context.Add(ttg);
            }

            _context.Add(Phong);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGhe(string id)
        {
            var phong = await _context.Phongs
                                        .Include(p => p.Ghes)
                                        .FirstOrDefaultAsync(p => p.MaPhong == id);

            if (phong != null)
            {
                var phonginghe = await _context.Ghes
                                              .Where(gh => gh.MaPhong == phong.MaPhong)
                                              .ToListAsync();

                var ttg = await _context.Trangthaighes
                                       .Where(tg => tg.MaPhong == phong.MaPhong)
                                       .ToListAsync();

                _context.RemoveRange(ttg); //xóa một vùng thực thể
                _context.RemoveRange(phonginghe);
                _context.Remove(phong); //xóa chỉ 1 cái thực thể
            }
            await _context.SaveChangesAsync();
        }

    }
}
