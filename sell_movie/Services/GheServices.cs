using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IGheService
    {
        Task<IEnumerable<Ghe>> GetAll();
        Task<Ghe> GetById(string id);
        Task<List<Ghe>> GetGheByMaPhongAsync(string maPhong);
        Task Create(Ghe entity);
        Task CreatebyModels(GheModels ghe);
        Task Update(string id, Ghe entity);
        Task Delete(string id);
    }

    public class GheServices : IGheService
    {
        private readonly IRepository<Ghe> _repository;
        private readonly web_cinema3Context _context;
        public GheServices(IRepository<Ghe> repository, web_cinema3Context context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Ghe entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Ghe>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Ghe> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Ghe entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(GheModels ghe)
        {
            var g = new Ghe
            {
                MaGhe = ghe.MaGhe,
                TenGhe = ghe.TenGhe,
                MaPhong = ghe.MaPhong
            };
            _context.Ghes.Add(g);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Ghe>> GetGheByMaPhongAsync(string maPhong)
        {
            return await _context.Ghes.Where(g => g.MaPhong == maPhong).ToListAsync();
        }
    }
}
