using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IThanhToanService
    {
        Task<IEnumerable<Thanhtoan>> GetAll();
        Task<Thanhtoan> GetById(string id);
        Task Create(Thanhtoan entity);
        Task AddAll(ThanhToanModels thanhToan);
        Task Update(string id, Thanhtoan entity);
        Task Delete(string id);
    }
    public class ThanhToanServices : IThanhToanService
    {
        private readonly IRepository<Thanhtoan> _repository;
        private readonly web_cinema3Context _context;
        public ThanhToanServices(IRepository<Thanhtoan> repository, web_cinema3Context context) 
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Thanhtoan entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Thanhtoan>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Thanhtoan> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Thanhtoan entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task AddAll(ThanhToanModels thanhToan )
        {
            var th = new Thanhtoan
            { 
               MaDatVe = thanhToan.MaDatVe,
               MaNhanVien = thanhToan.MaNhanVien,
                MaThanhToan = thanhToan.MaThanhToan,
                NgayThanhToan = thanhToan.NgayThanhToan,
                Phuongthucthanhtoan = thanhToan.Phuongthucthanhtoan,
            };
           _context.Add(th);
            await _context.SaveChangesAsync();

        }
    }
}
