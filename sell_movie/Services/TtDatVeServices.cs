using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ITtDatVeService
    {
        Task<IEnumerable<Ttdatve>> GetAll();
        Task<Ttdatve> GetById(string id);
        Task Create(Ttdatve entity);
        Task CreatebyModels(TtdatveModels ttdatve);
        Task Update(string id, Ttdatve entity);
        Task Delete(string id);
    }
    public class TtDatVeServices : ITtDatVeService
    {
        private readonly IRepository<Ttdatve> _repository;
        private readonly web_cinema3Context _context;
        public TtDatVeServices(IRepository<Ttdatve> repository, web_cinema3Context context)
        {
            _repository = repository;
            _context = context;
        }
        public int MaDatVe { get; set; }
        public string MaLichPhim { get; set; } = null!;
        public DateTime NgayDat { get; set; }

        public async Task Create(Ttdatve entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Ttdatve>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Ttdatve> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Ttdatve entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(TtdatveModels ttdatve)
        {
            var tt = new Ttdatve
            {
                MaDatVe = ttdatve.MaDatVe,
                MaLichPhim = ttdatve.MaLichPhim,
                NgayDat = ttdatve.NgayDat

            };
            _context.Ttdatves.Add(tt);
            await _context.SaveChangesAsync();
        }

    }
    
}
