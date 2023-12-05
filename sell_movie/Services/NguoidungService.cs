using sell_movie.Models;
using sell_movie.Repository;

namespace Sell_movie_ticket.Services
{
    public interface INguoidungService
    {
        Task<IEnumerable<NguoidungModels>> GetAllNguoidungs();
        Task<NguoidungModels> GetNguoidungByUsername(string username);
        Task AddNguoidung(NguoidungModels nguoidung);
        Task UpdateNguoidung(string username, NguoidungModels nguoidung);
        Task DeleteNguoidung(string username);
    }

    public class NguoidungService : INguoidungService
    {
        private readonly IRepository<NguoidungModels> _nguoidungRepository;

        public NguoidungService(IRepository<NguoidungModels> nguoidungRepository)
        {
            _nguoidungRepository = nguoidungRepository;
        }

        public async Task<IEnumerable<NguoidungModels>> GetAllNguoidungs()
        {
            return await _nguoidungRepository.GetAll();
        }

        public async Task<NguoidungModels> GetNguoidungByUsername(string username)
        {
            return await _nguoidungRepository.GetById(username);
        }

        public async Task AddNguoidung(NguoidungModels nguoidung)
        {
            await _nguoidungRepository.Create(nguoidung);
        }

        public async Task UpdateNguoidung(string username, NguoidungModels nguoidung)
        {
            await _nguoidungRepository.Update(username, nguoidung);
        }

        public async Task DeleteNguoidung(string username)
        {
            await _nguoidungRepository.Delete(username);
        }
    }
}
