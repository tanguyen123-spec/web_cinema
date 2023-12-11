using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class NhanVienServices : MyRepository<Nhanvien>
    {
        private readonly web_cinema3Context context_;
        public NhanVienServices(web_cinema3Context context) : base(context)
        {
            context_ = context;
        }
        public async Task CreatebyModels(NhanvienModels nhanvien)
        {
            var nv = new Nhanvien
            {
                MaNhanVien = nhanvien.MaNhanVien,
                TenNhanVien = nhanvien.TenNhanVien,
                SoDienThoai = nhanvien.SoDienThoai,
                DiaChi = nhanvien.DiaChi,
                Gioitinh = nhanvien.Gioitinh,
                Ngaysinh = nhanvien.Ngaysinh
            };

           

          

            context_.Nhanviens.Add(nv);
            await context_.SaveChangesAsync();

            var random = new Random();
            var username = "user" + random.Next(1000, 9999); // Tạo username ngẫu nhiên
            var password = Guid.NewGuid().ToString(); // Tạo password ngẫu nhiên

            var nguoidung = new Nguoidung
            {
                MaNhanVien = nv.MaNhanVien,
                Username = username,
                Password = password,
                Role = false,
                Email = ""
            };
            context_.Nguoidungs.Add(nguoidung);
            await context_.SaveChangesAsync();
        }
        public async Task Delete(string id)
        {
            var nhanvien = await GetById(id)
;
            if (nhanvien != null)
            {
                // Xóa các bản ghi liên quan trong bảng "nguoidung"
                var relatedNguoidung = await context_.Nguoidungs
                    .Where(nd => nd.MaNhanVien == id)
                    .ToListAsync();

                if (relatedNguoidung.Count > 0)
                {
                    context_.Nguoidungs.RemoveRange(relatedNguoidung);
                }
                var relatedThanhtoan = await context_.Thanhtoans
                    .Where(tt => tt.MaNhanVien == id)
                    .ToListAsync();

                if (relatedThanhtoan.Count > 0)
                {
                    context_.Thanhtoans.RemoveRange(relatedThanhtoan);
                }

                // Xóa nhân viên
                context_.Nhanviens.Remove(nhanvien);
                await context_.SaveChangesAsync();
            }
        }
    }
}