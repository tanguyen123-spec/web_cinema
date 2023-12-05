using System.Collections.Generic;
using sell_movie.Repository;
using sell_movie.Models;
 

namespace sell_movie.Services
{
    public interface ILichChieuService
    {
        Task<IEnumerable<LichChieuModels>> GetAll();
        Task<LichChieuModels> GetById(string id);
        Task Add(LichChieuModels lichchieu);
        Task Update(string id, LichChieuModels lichchieu);
        Task Delete(string id);
    }

    public class LichChieuService : ILichChieuService
    {
        private readonly IRepository<LichChieuModels> _lichChieuRepository;

        public LichChieuService(IRepository<LichChieuModels> lichChieuRepository)
        {
            _lichChieuRepository = lichChieuRepository;
        }

        public async Task<IEnumerable<LichChieuModels>> GetAll()
        {
            return await _lichChieuRepository.GetAll();
        }

        public async Task<LichChieuModels> GetById(string id)
        {
            return await _lichChieuRepository.GetById(id);
        }

        public async Task Add(LichChieuModels lichchieu)
        {
            await _lichChieuRepository.Create(lichchieu);
        }

        public async Task Update(string id, LichChieuModels lichchieu)
        {
            await _lichChieuRepository.Update(id, lichchieu);
        }

        public async Task Delete(string id)
        {
            await _lichChieuRepository.Delete(id);
        }
    }
}
