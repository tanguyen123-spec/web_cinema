using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;


namespace sell_movie.Repository
{
    public class NhanvienRepository : IRepository<NhanvienModels>
    {
        private readonly web_cinema3Context _context;

        public NhanvienRepository(web_cinema3Context context)
        {
            _context = context;
        }

        public async Task Create(NhanvienModels entity)
        {
            var nhanvien = new Nhanvien
            {
                MaNhanVien = entity.MaNhanVien,
                TenNhanVien = entity.TenNhanVien,
                SoDienThoai = entity.SoDienThoai,
                DiaChi = entity.DiaChi,
                Gioitinh = entity.Gioitinh,
                Ngaysinh = entity.Ngaysinh
            };

            _context.Add(nhanvien);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null)
            {
                _context.Remove(nhanvien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<NhanvienModels>> GetAll()
        {
            var nhanviens = await _context.Nhanviens.ToListAsync();
            return nhanviens.Select(nv => new NhanvienModels
            {
                MaNhanVien = nv.MaNhanVien,
                TenNhanVien = nv.TenNhanVien,
                SoDienThoai = nv.SoDienThoai,
                DiaChi = nv.DiaChi,
                Gioitinh = nv.Gioitinh,
                Ngaysinh = nv.Ngaysinh
            });
        }

        public async Task<NhanvienModels> GetById(string id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null)
            {
                return new NhanvienModels
                {
                    MaNhanVien = nhanvien.MaNhanVien,
                    TenNhanVien = nhanvien.TenNhanVien,
                    SoDienThoai = nhanvien.SoDienThoai,
                    DiaChi = nhanvien.DiaChi,
                    Gioitinh = nhanvien.Gioitinh,
                    Ngaysinh = nhanvien.Ngaysinh
                };
            }
            return null;
        }

        public async Task Update(string id, NhanvienModels entity)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null)
            {
                nhanvien.MaNhanVien = entity.MaNhanVien;
                nhanvien.TenNhanVien = entity.TenNhanVien;
                nhanvien.SoDienThoai = entity.SoDienThoai;
                nhanvien.DiaChi = entity.DiaChi;
                nhanvien.Gioitinh = entity.Gioitinh;
                nhanvien.Ngaysinh = entity.Ngaysinh;

                await _context.SaveChangesAsync();
            }
        }
    }
}
