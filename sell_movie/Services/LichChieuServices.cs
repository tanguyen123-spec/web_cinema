using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ILichChieuService
    {
        Task<IEnumerable<Lichchieu>> GetAll();
        Task<Lichchieu> GetById(string id);
        Task Create(Lichchieu entity);
        Task CreatebyModels(LichchieuModels lichchieu);
        Task Update(string id, Lichchieu entity);
        Task Delete(string id);
    }
    public class LichChieuServices : ILichChieuService
    {
        private readonly IRepository<Lichchieu> _repository;
        private readonly web_cinema3Context context_;
        public LichChieuServices(IRepository<Lichchieu> repository, web_cinema3Context context) 
        {
            _repository = repository;
            context_ = context;
        }
        public async Task Create(Lichchieu entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Lichchieu>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Lichchieu> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Lichchieu entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(LichchieuModels lichchieu)
        {
            var lc = new Lichchieu
            {

                MaLichChieu = lichchieu.MaLichChieu,
                NgayChieu = lichchieu.NgayChieu,
                GioChieu = new TimeSpan(lichchieu.Gio, lichchieu.Phut, 0)

            };
            context_.Lichchieus.Add(lc);
            await context_.SaveChangesAsync();
        }
    }
}
