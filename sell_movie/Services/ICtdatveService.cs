using sell_movie.Models;

namespace sell_movie.Services
{
    public interface ICtdatveService
    {
        Task<IEnumerable<CtdatveModels>> GetAll();
        Task<CtdatveModels> GetById(string id);
        Task Add(CtdatveModels ctdatve);
        Task Update(string id, CtdatveModels ctdatve);
        Task Delete(string id);
    }
}