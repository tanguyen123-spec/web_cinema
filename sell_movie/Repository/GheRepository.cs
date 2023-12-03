using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Repository
{
    public class GheRepository : IRepository<GheModels>
    {
        private readonly web_cinema3Context _context;
        public GheRepository(web_cinema3Context context)
        {
            _context = context;
        }

        public async Task Create(GheModels entity)
        {
            var ghe = new Ghe
            {
                MaGhe = entity.MaGhe,
                MaPhong = entity.MaPhong,
                TenGhe = entity.TenGhe,
            };
            _context.Add(ghe);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var ghe = (from gh in _context.Ghes where gh.MaGhe == id select gh).FirstOrDefault();
            if(ghe != null)
            {
                _context.Remove(ghe);
                await _context.SaveChangesAsync();            }
        }

        public async Task<IEnumerable<GheModels>> GetAll()
        {
            var ghe = await _context.Ghes.ToListAsync();
            return ghe.Select(gh => new GheModels
            {
                MaGhe = gh.MaGhe,
                MaPhong = gh.MaPhong,
                TenGhe = gh.TenGhe,
            });
        }

        public async Task<GheModels> GetById(string id)
        {
            var ghe = (from gh in _context.Ghes where gh.MaGhe == id select gh).FirstOrDefault();
            if(ghe != null)
            {
                return new GheModels
                { MaGhe = ghe.MaGhe,
                  TenGhe = ghe.TenGhe,
                  MaPhong = ghe.MaPhong,
                };
            }
            return null;
        }

        public async Task Update(string id, GheModels entity)
        {
            var ghe = await (from gh in _context.Ghes where gh.MaGhe == id select gh).SingleOrDefaultAsync();
            if(ghe != null)
            {
                ghe.MaGhe = entity.MaGhe;
                ghe.MaPhong = entity.MaPhong;
                ghe.TenGhe = entity.TenGhe;
            }
        }
    }
}
