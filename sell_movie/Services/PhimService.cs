using System.Collections.Generic;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IPhimService
    {
        Task<IEnumerable<PhimModels>> GetAll();
        Task<PhimModels> GetById(string id);
        Task Add(PhimModels phim);
        Task Update(string id, PhimModels phim);
        Task Delete(string id);
    }

    public class PhimService : IPhimService
    {
        private readonly IRepository<PhimModels> _phimRepository;

        public PhimService(IRepository<PhimModels> phimRepository)
        {
            _phimRepository = phimRepository;
        }

        public async Task<IEnumerable<PhimModels>> GetAll()
        {
            return await _phimRepository.GetAll();
        }

        public async Task<PhimModels> GetById(string id)
        {
            return await _phimRepository.GetById(id);
        }

        public async Task Add(PhimModels phim)
        {
            await _phimRepository.Create(phim);
        }

        public async Task Update(string id, PhimModels phim)
        {
            await _phimRepository.Update(id, phim);
        }

        public async Task Delete(string id)
        {
            await _phimRepository.Delete(id);
        }
    }
}
