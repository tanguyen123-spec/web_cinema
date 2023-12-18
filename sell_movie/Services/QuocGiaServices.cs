using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IQuocGiaService
    {
        Task<IEnumerable<Quocgium>> GetAll();
        Task<Quocgium> GetById(string id);
        Task Create(Quocgium entity);
        Task CreatebyModels(QuocGiaModels quocgia);
        Task Update(string id, Quocgium entity);
        Task Delete(string id);
    }
    public class QuocGiaServices : IQuocGiaService
    {
        private readonly IRepository<Quocgium> _repository;
        private readonly web_cinema3Context _context;
        public QuocGiaServices(IRepository<Quocgium> repository, web_cinema3Context context) 
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Quocgium entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Quocgium>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Quocgium> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Quocgium entity)
        {
            await _repository.Update(id, entity);
        }
        public string MaQuocgia { get; set; } = null!;
        public string TenQuocGia { get; set; } = null!;
        public async Task CreatebyModels(QuocGiaModels quocgia)
        {
            var qg = new Quocgium
            {
                MaQuocgia = quocgia.MaQuocgia,
                TenQuocGia = quocgia.TenQuocGia,
               
            };
            _context.Quocgia.Add(qg);
            await _context.SaveChangesAsync();
        }
    }
}
