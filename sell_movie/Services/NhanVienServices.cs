using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface INhanVienService
    {
        Task<IEnumerable<Nhanvien>> GetAll();
        Task<Nhanvien> GetById(string id);
        Task Create(Nhanvien entity);
        Task CreatebyModels(NhanvienModels nhanvien);
        Task Update(string id, Nhanvien entity);
        Task Delete(string id);
        Task Delete2(string id);
    }
    public class NhanVienServices : INhanVienService
    {
        private readonly IRepository<Nhanvien> _repository;
        private readonly web_cinema3Context context_;
        public NhanVienServices(IRepository<Nhanvien> repository, web_cinema3Context context) 
        {
            _repository = repository;
            context_ = context;
        }
        public async Task Create(Nhanvien entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Nhanvien>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Nhanvien> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Nhanvien entity)
        {
            await _repository.Update(id, entity);
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
        public async Task Delete2(string id)
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