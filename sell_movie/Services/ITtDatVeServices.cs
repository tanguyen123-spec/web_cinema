using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ITtDatVeServices
    {
        Task<IEnumerable<TtdatveModels>> GetAll();
        Task<TtdatveModels> GetById(string id);
        Task Add(TtdatveModels ctdatve);
        Task Update(string id, TtdatveModels ctdatve);
        Task Delete(string id);
    }
}