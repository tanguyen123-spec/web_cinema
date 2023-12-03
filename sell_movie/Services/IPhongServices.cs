using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IPhongServices
    {
        Task<IEnumerable<PhongModels>> GetAll();
        Task<PhongModels> GetById(string id);
        Task Add(PhongModels Phong);
        Task Update(string id, PhongModels Phong);
        Task Delete(string id);

        //Bonuss
        Task AddGheByPhong(PhongModels phong);
        
    }
}
