using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class TtDatVeServices : ITtDatVeServices
    {
        private readonly IRepository<TtdatveModels> repository_;
        public TtDatVeServices(IRepository<TtdatveModels> repository) 
        { 
            repository_ = repository;
        }

        public async Task Add(TtdatveModels ctdatve)
        {
            await repository_.Create(ctdatve);
        }

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<TtdatveModels>> GetAll()
        {
            return await repository_.GetAll();
        }

        public async Task<TtdatveModels> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, TtdatveModels ctdatve)
        {
             await repository_.Update(id, ctdatve);
        }
    }
}
