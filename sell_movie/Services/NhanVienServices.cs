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
        }
    }
}
