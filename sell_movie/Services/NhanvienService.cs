using System.Collections.Generic;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface INhanvienService
    {
        Task<IEnumerable<NhanvienModels>> GetAll();
        Task<NhanvienModels> GetById(string id);
        Task Add(NhanvienModels nhanvien);
        Task Update(string id, NhanvienModels nhanvien);
        Task Delete(string id);
    }

    public class NhanvienService : INhanvienService
    {
        private readonly IRepository<NhanvienModels> _nhanvienRepository;

        public NhanvienService(IRepository<NhanvienModels> nhanvienRepository)
        {
            _nhanvienRepository = nhanvienRepository;
        }

        public async Task<IEnumerable<NhanvienModels>> GetAll()
        {
            return await _nhanvienRepository.GetAll();
        }

        public async Task<NhanvienModels> GetById(string id)
        {
            return await _nhanvienRepository.GetById(id);
        }

        public async Task Add(NhanvienModels nhanvien)
        {
            await _nhanvienRepository.Create(nhanvien);
        }

        public async Task Update(string id, NhanvienModels nhanvien)
        {
            await _nhanvienRepository.Update(id, nhanvien);
        }

        public async Task Delete(string id)
        {
            await _nhanvienRepository.Delete(id);
        }
    }
}
