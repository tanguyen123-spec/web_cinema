using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IGheServices
    {
        Task<IEnumerable<GheModels>> GetAll();
        Task<GheModels> GetById(string id);
        Task Add(GheModels Ghe);
        Task Update(string id, GheModels Ghe);
        Task Delete(string id);
    }
}
