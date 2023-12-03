using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;
namespace sell_movie.Services
{
    public interface IGiaveService
    {
        Task<IEnumerable<GiaveModels>> GetAllGiaveModels();
        Task<GiaveModels> GetGiaveModelsById(string maGiaVe);
        Task AddGiaveModels(GiaveModels giaveModels);
        Task UpdateGiaveModels(GiaveModels giaveModels);
        Task DeleteGiaveModels(string maGiaVe);
    }

    public class GiaveService : IGiaveService
    {
        private readonly IGiaveRepository _giaveRepository;
        private readonly IMapper _mapper;

        public GiaveService(IGiaveRepository giaveRepository, IMapper mapper)
        {
            _giaveRepository = giaveRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GiaveModels>> GetAllGiaveModels()
        {
            var giaveModels = await _giaveRepository.GetAllGiave();
            return _mapper.Map<IEnumerable<Giave>, IEnumerable<GiaveModels>>(giaveModels);
        }

        public async Task<GiaveModels> GetGiaveModelsById(string maGiaVe)
        {
            var giaveModels = await _giaveRepository.GetGiaveById(maGiaVe);
            return _mapper.Map<Giave, GiaveModels>(giaveModels);
        }

        public async Task AddGiaveModels(GiaveModels giaveModels)
        {
            var giaveEntity = _mapper.Map<GiaveModels, Giave>(giaveModels);
            await _giaveRepository.AddGiave(giaveEntity);
        }

        public async Task UpdateGiaveModels(GiaveModels giaveModels)
        {
            var giaveEntity = _mapper.Map<GiaveModels, Giave>(giaveModels);
            await _giaveRepository.UpdateGiave(giaveEntity);
        }

        public async Task DeleteGiaveModels(string maGiaVe)
        {
            await _giaveRepository.DeleteGiave(maGiaVe);
        }
    }
}
