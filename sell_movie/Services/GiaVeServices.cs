using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IGiaVeService
    {
        Task<IEnumerable<Giave>> GetAll();
        Task<Giave> GetById(string id);
        Task Create(Giave entity);
        Task CreatebyModels(GiaveModels giaves);
        Task Update(string id, Giave entity);
        Task Delete(string id);
    }
    public class GiaVeServices : IGiaVeService
    {
        private readonly IRepository<Giave> _repository;
        private readonly web_cinema3Context _context;
        public GiaVeServices(IRepository<Giave> repository, web_cinema3Context context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Giave entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Giave>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Giave> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Giave    entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(GiaveModels giaves)
        {
            var giave = new Giave
            {
                MaGiaVe = giaves.MaGiaVe,
                TenLoaiVe = giaves.TenLoaiVe,
                GiaVe1 = giaves.GiaVe1
            };
            _context.Giaves.Add(giave);
            await _context.SaveChangesAsync();
        }
    }
}
