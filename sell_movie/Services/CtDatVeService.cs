using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class CtdatveService : ICtdatveService
    {
        private readonly IRepository<CtdatveModels> _ctdatveRepository;
        

        public CtdatveService(IRepository<CtdatveModels> ctdatveRepository )
        {
            _ctdatveRepository = ctdatveRepository;
        }

        public async Task<IEnumerable<CtdatveModels>> GetAll()
        {
            
            return await _ctdatveRepository.GetAll();
        }

        public async Task<CtdatveModels> GetById(string id)
        {
            return await _ctdatveRepository.GetById(id); 
        }

        public async Task Add(CtdatveModels ctdatve)
        {
            await _ctdatveRepository.Create(ctdatve);
        }

        public async Task Update(string id, CtdatveModels ctdatve)
        {
            await _ctdatveRepository.Update(id, ctdatve);
        }
        public async Task Delete(string id)
        {
            await _ctdatveRepository.Delete(id);
        }
    }
}
