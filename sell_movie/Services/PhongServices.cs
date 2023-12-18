using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IPhongService
    {
        Task<IEnumerable<Phong>> GetAll();
        Task<Phong> GetById(string id);
        Task Create(Phong entity);
        Task CustomCreate(PhongModels phong);
        Task Update(string id, Phong entity);
        Task Delete(string id);
        Task DeleteGhe(string id);
    }
    public class PhongServices : IPhongService
    {
        private readonly IRepository<Phong> _repository;
        private readonly web_cinema3Context _context;
        public PhongServices(IRepository<Phong> repository, web_cinema3Context context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Phong entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Phong>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Phong> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Phong entity)
        {
            await _repository.Update(id, entity);
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
