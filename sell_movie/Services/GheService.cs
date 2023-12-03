using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class GheService :IGheServices
    {
        private readonly IRepository<GheModels> _GheRepository;


        public GheService(IRepository<GheModels> GheRepository)
        {
            _GheRepository = GheRepository;
        }

        public async Task<IEnumerable<GheModels>> GetAll()
        {

            return await _GheRepository.GetAll();
        }

        public async Task<GheModels> GetById(string id)
        {
            return await _GheRepository.GetById(id);
        }

        public async Task Add(GheModels ghe)
        {
            await _GheRepository.Create(ghe);
        }

        public async Task Update(string id, GheModels ghe)
        {
            await _GheRepository.Update(id, ghe);
        }
        public async Task Delete(string id)
        {
            await _GheRepository.Delete(id);
        }
    }
}

