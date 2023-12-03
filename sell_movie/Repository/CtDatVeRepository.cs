using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Repository
{
    public class CtdatveRepository : IRepository<CtdatveModels>
    {
        private readonly web_cinema3Context _dbContext;

        public CtdatveRepository(web_cinema3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CtdatveModels>> GetAll()
        {
            var ct = await _dbContext.Ctdatves.ToListAsync();
            return ct.Select(c => new CtdatveModels
            { GiaVe = c.GiaVe,
               MaDatVe = c.MaDatVe,
               MaGhe    = c .MaGhe,
            });
        }

        public async Task<CtdatveModels> GetById(string id)
        {
            var ct = await _dbContext.Ctdatves
                .Where(kh => kh.MaDatVe.ToString() == id)
                .SingleOrDefaultAsync();
            if (ct != null)
            {
                return new CtdatveModels
                {
                    GiaVe = ct.GiaVe,
                    MaDatVe = ct.MaDatVe,
                    MaGhe = ct.MaGhe,
                };
            }
            return null;
        }

        public async Task Create(CtdatveModels ctdatve)
        {
            var ct = new Ctdatve
            {
                GiaVe = ctdatve.GiaVe,
                MaDatVe = ctdatve.MaDatVe,
                MaGhe = ctdatve.MaGhe
            };
            _dbContext.Add(ct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(string id, CtdatveModels ctdatve)
        {
            var existingCT = _dbContext.Ctdatves.SingleOrDefault(kh => kh.MaDatVe.ToString() == id);

            if (existingCT != null)
            {
                existingCT.MaDatVe = ctdatve.MaDatVe;
                existingCT.GiaVe = ctdatve .GiaVe;
                existingCT.MaGhe = ctdatve.MaGhe;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(string id)
        {
            var CTdatve = (from ct in _dbContext.Ctdatves where ct.MaDatVe.ToString() == id select ct).SingleOrDefault();
            if(CTdatve != null)
            {
                 _dbContext.Ctdatves.Remove(CTdatve);
                 await _dbContext.SaveChangesAsync();
            }    
        }
    }
}
