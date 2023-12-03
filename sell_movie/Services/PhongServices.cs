using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class PhongServices : IPhongServices
    {
        
        private readonly web_cinema3Context context_;
        private readonly IRepository<PhongModels> _repository;
        public PhongServices(IRepository<PhongModels> repository, web_cinema3Context context)
        {
            _repository = repository;
            context_ = context;
        }

        public async Task Add(PhongModels Phong)
        {
            await _repository.Create(Phong); 
            
        }

        public async Task Delete(string id)
        {
             await _repository.Delete(id);
        }

        public async Task<IEnumerable<PhongModels>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<PhongModels> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, PhongModels Phong)
        {
            await _repository.Update(id, Phong);
        }


        public async Task AddGheByPhong(PhongModels phong)
        {
            var phong1 = new Phong
            {
                TenPhong = phong.TenPhong,
                MaPhong = phong.MaPhong,
                SoChoNgoi = phong.SoChoNgoi,
                SoHang = phong.SoHang,
                Socot = phong.Socot,
            };
            context_.Add(phong1);
            phong1.Ghes = new List<Ghe>();
            foreach (var existingGhe in phong1.Ghes)
            {
                context_.Entry(existingGhe).State = EntityState.Detached;
            }
            for (int hang = 1; hang <= phong1.SoHang; hang++)
            {
                for (int cot = 1; cot <= phong1.Socot; cot++)
                {
                    var tenGhe = $"{hang}-{cot}";
                    var maGhe = $"{phong1.MaPhong}-{hang*cot}";
                    var ghe = new Ghe
                    {
                        MaGhe = maGhe,
                        TenGhe = tenGhe,
                    };

                    phong1.Ghes.Add(ghe);
                }
            }
            await context_.SaveChangesAsync();
        }
    }
}
