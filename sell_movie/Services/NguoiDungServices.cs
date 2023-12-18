using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface INguoiDungService
    {
        Task<IEnumerable<Nguoidung>> GetAll();
        Task<Nguoidung> GetById(string id);
        Task Create(Nguoidung entity);
        Task CreatebyModels(NguoidungModels nguoidung);
        Task Update(string id, Nguoidung entity);
        Task Delete(string id);
    }
    public class NguoiDungServices : INguoiDungService
    {
        private readonly IRepository<Nguoidung> _repository;
        private readonly web_cinema3Context context_;
        public NguoiDungServices(IRepository<Nguoidung> repository, web_cinema3Context context) 
        {
            _repository = repository;
            context_ = context;
        }
        public async Task Create(Nguoidung entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Nguoidung>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Nguoidung> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Nguoidung entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(NguoidungModels nguoidung)
        {
        var nd = new Nguoidung
            {

            Username = nguoidung.Username,
            Password = nguoidung.Password,
            Email = nguoidung.Email,
            Role = nguoidung.Role,
            MaNhanVien = nguoidung.MaNhanVien,
           

        };
            context_.Nguoidungs.Add(nd);
            await context_.SaveChangesAsync();
        }
    }
    
}
