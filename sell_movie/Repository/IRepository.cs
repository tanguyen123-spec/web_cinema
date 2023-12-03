using sell_movie.Enities;
using sell_movie.Repository;

namespace sell_movie.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Create(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
        //Task<IEnumerable<T>> GetPage(int page, int pageSize);
        //Task<IEnumerable<T>> Search(string keyword);
    }
}
