using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IQuocGiaService
    {
        Task<IEnumerable<QuocGiaModels>> GetAll();
        Task<QuocGiaModels> GetById(string id);
        Task Add(QuocGiaModels quocGia);
        Task Update(string id, QuocGiaModels quocGia);
        Task Delete(string id);
    }

    public class QuocGiaService : IQuocGiaService
    {
        private readonly IQuocGiaRepository _quocGiaRepository;
        private readonly IMapper _mapper;

        public QuocGiaService(IQuocGiaRepository quocGiaRepository, IMapper mapper)
        {
            _quocGiaRepository = quocGiaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuocGiaModels>> GetAll()
        {
            var quocgiaEntities = await _quocGiaRepository.GetAll();
            return _mapper.Map<IEnumerable<QuocGiaModels>>(quocgiaEntities);
        }

        public async Task<QuocGiaModels> GetById(string id)
        {
            var quocgiaEntity = await _quocGiaRepository.GetById(id);
            return _mapper.Map<QuocGiaModels>(quocgiaEntity);
        }

        public async Task Add(QuocGiaModels quocGia)
        {
            var quocgiaEntity = _mapper.Map<Quocgium>(quocGia);
            await _quocGiaRepository.Add(quocgiaEntity);
        }

        public async Task Update(string id, QuocGiaModels quocGia)
        {
            var existingQuocGiaEntity = await _quocGiaRepository.GetById(id);
            if (existingQuocGiaEntity == null)
            {
                // Handle not found scenario
            }
            var quocgiaEntity = _mapper.Map<Quocgium>(quocGia);
            // Update properties of existingQuocGiaEntity with quocgiaEntity
            existingQuocGiaEntity.MaQuocgia = quocgiaEntity.MaQuocgia;
            existingQuocGiaEntity.TenQuocGia = quocgiaEntity.TenQuocGia;
            await _quocGiaRepository.Update(existingQuocGiaEntity);
        }

        public async Task Delete(string id)
        {
            await _quocGiaRepository.Delete(id);
        }
    }
}