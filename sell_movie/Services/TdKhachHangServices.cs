using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ITdKhachHangService
    {
        Task<IEnumerable<Tdkhachhang>> GetAll();
        Task<Tdkhachhang> GetById(string id);
        Task Create(Tdkhachhang entity);
        Task Addttkh(TdKhachHangModels td);
        Task Update(string id, Tdkhachhang entity);
        Task Delete(string id);
    }
    public class TdKhachHangServices : ITdKhachHangService
    {
        private readonly IRepository<Tdkhachhang> _repository;
        private readonly web_cinema3Context _context;

        public TdKhachHangServices( IRepository<Tdkhachhang> repository, web_cinema3Context context ) 
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Tdkhachhang entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Tdkhachhang>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Tdkhachhang> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Tdkhachhang entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task Addttkh (TdKhachHangModels td)
        {
            var ttkh = new Tdkhachhang
            {
                Diemkhachhang = td.Diemkhachhang,
                HangKh = td.HangKh,
                Makhachhang = td.Makhachhang,
            };
            _context.Add(ttkh);
            await _context.SaveChangesAsync();  
        }
    }
}
