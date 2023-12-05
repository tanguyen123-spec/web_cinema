
using sell_movie.Repository;
using sell_movie.Models;
using sell_movie.Mapping;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using sell_movie.Enities;

namespace sell_movie.Services
{
    public interface ITrangThaiGheService
    {
        Task<IEnumerable<TrangThaiGheModels>> GetAllTrangThaiGhes();
        Task<TrangThaiGheModels> GetTrangThaiGheById(string id);
        Task CreateTrangThaiGhe(TrangThaiGheModels trangThaiGheModels);
        Task UpdateTrangThaiGhe(string id, TrangThaiGheModels trangThaiGheModels);
        Task DeleteTrangThaiGhe(string id);
    }

    public class TrangThaiGheService : ITrangThaiGheService
    {
        private readonly IRepository<Trangthaighe> _trangThaiGheRepository;
        private readonly IMapper _mapper;

        public TrangThaiGheService(IRepository<Trangthaighe> trangThaiGheRepository, IMapper mapper)
        {
            _trangThaiGheRepository = trangThaiGheRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrangThaiGheModels>> GetAllTrangThaiGhes()
        {
            var trangThaiGhes = await _trangThaiGheRepository.GetAll();
            var trangThaiGheModels = _mapper.Map<IEnumerable<TrangThaiGheModels>>(trangThaiGhes);
            return trangThaiGheModels;
        }

        public async Task<TrangThaiGheModels> GetTrangThaiGheById(string id)
        {
            var trangThaiGhe = await _trangThaiGheRepository.GetById(id);
            var trangThaiGheModel = _mapper.Map<TrangThaiGheModels>(trangThaiGhe);
            return trangThaiGheModel;
        }

        public async Task CreateTrangThaiGhe(TrangThaiGheModels trangThaiGheModels)
        {
            var trangThaiGhe = _mapper.Map<Trangthaighe>(trangThaiGheModels);
            await _trangThaiGheRepository.Create(trangThaiGhe);
        }

        public async Task UpdateTrangThaiGhe(string id, TrangThaiGheModels trangThaiGheModels)
        {
            var existingTrangThaiGhe = await _trangThaiGheRepository.GetById(id);
            if (existingTrangThaiGhe != null)
            {
                var updatedTrangThaiGhe = _mapper.Map(trangThaiGheModels, existingTrangThaiGhe);
                await _trangThaiGheRepository.Update(id, updatedTrangThaiGhe);
            }
        }

        public async Task DeleteTrangThaiGhe(string id)
        {
            await _trangThaiGheRepository.Delete(id);
        }
    }
}