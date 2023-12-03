using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ILichChieuPhimServices
    {
        Task<IEnumerable<LichchieuphimModels>> GetAll();
        Task<LichchieuphimModels> GetById(string id);
        Task Add(LichchieuphimModels ctdatve);
        Task Update(string id, LichchieuphimModels ctdatve);
        Task Delete(string id);
    }
}
