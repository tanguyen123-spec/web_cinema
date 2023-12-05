using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using sell_movie.Models;
using sell_movie.Enities;


namespace sell_movie.Services
{
    public interface IThanhtoanService
    {
        Task<IEnumerable<ThanhToanModels>> GetAllThanhtoanModels();
        Task<ThanhToanModels> GetThanhtoanModelsById(int id);
        Task AddThanhtoanModels(ThanhToanModels thanhtoanModels);
        Task UpdateThanhtoanModels(ThanhToanModels thanhtoanModels);
        Task DeleteThanhtoanModels(int id);
    }
    public class ThanhtoanService : IThanhtoanService
    {
        private readonly IThanhtoanRepository _thanhtoanModelsRepository;
        private readonly IMapper _mapper;

        public ThanhtoanService(IThanhtoanRepository thanhtoanRepository, IMapper mapper)
        {
            _thanhtoanModelsRepository = thanhtoanRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ThanhToanModels>> GetAllThanhtoanModels()
        {
            var thanhtoanModels = await _thanhtoanModelsRepository.GetAllThanhtoan();
            return _mapper.Map<IEnumerable<Thanhtoan>, IEnumerable<ThanhToanModels>>(thanhtoanModels);
        }

        public async Task<ThanhToanModels> GetThanhtoanModelsById(int id)
        {
            var thanhtoanModels = await _thanhtoanModelsRepository.GetThanhtoanById(id);
            return _mapper.Map<Thanhtoan, ThanhToanModels>(thanhtoanModels);
        }

        public async Task AddThanhtoanModels(ThanhToanModels thanhtoanModels)
        {
            var thanhtoanEntity = _mapper.Map<ThanhToanModels, Thanhtoan>(thanhtoanModels);
            await _thanhtoanModelsRepository.AddThanhtoan(thanhtoanEntity);
        }

        public async Task UpdateThanhtoanModels(ThanhToanModels thanhtoanModels)
        {
            var thanhtoanEntity = _mapper.Map<ThanhToanModels, Thanhtoan>(thanhtoanModels);
            await _thanhtoanModelsRepository.UpdateThanhtoan(thanhtoanEntity);
        }

        public async Task DeleteThanhtoanModels(int id)
        {
            await _thanhtoanModelsRepository.DeleteThanhtoan(id);
        }
    }

}
