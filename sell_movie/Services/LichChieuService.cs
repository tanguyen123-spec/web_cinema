using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;
using System;
using System.Collections.Generic;

namespace sell_movie.Services
{
    public interface ILichchieuService
    {
        IEnumerable<LichchieuModels> GetAllLichchieu();
        LichchieuModels GetLichchieuById(string id);
        void AddLichchieu(LichchieuModels lichchieu);
        void UpdateLichchieu(LichchieuModels lichchieu);
        void DeleteLichchieu(string id);
    }

    public class LichchieuService : ILichchieuService
    {
        private readonly ILichchieuRepository _lichchieuRepository;
        private readonly IMapper _mapper;

        public LichchieuService(ILichchieuRepository lichchieuRepository, IMapper mapper)
        {
            _lichchieuRepository = lichchieuRepository;
            _mapper = mapper;
        }

        public IEnumerable<LichchieuModels> GetAllLichchieu()
        {
            var lichchieus = _lichchieuRepository.GetAll();
            return _mapper.Map<IEnumerable<LichchieuModels>>(lichchieus);
        }

        public LichchieuModels GetLichchieuById(string id)
        {
            var lichchieu = _lichchieuRepository.GetById(id);
            return _mapper.Map<LichchieuModels>(lichchieu);
        }

        public void AddLichchieu(LichchieuModels lichchieu)
        {
            var lichchieuEntity = _mapper.Map<Lichchieu>(lichchieu);
            _lichchieuRepository.Add(lichchieuEntity);
        }

        public void UpdateLichchieu(LichchieuModels lichchieu)
        {
            var lichchieuEntity = _mapper.Map<Lichchieu>(lichchieu);
            _lichchieuRepository.Update(lichchieuEntity);
        }

        public void DeleteLichchieu(string id)
        {
            _lichchieuRepository.Delete(id);
        }
    }
}