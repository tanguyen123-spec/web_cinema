using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sell_movie.Models;
using sell_movie.Enities;

namespace sell_movie.Repository
{
    public interface IGiaveRepository
    {
        Task<IEnumerable<Giave>> GetAllGiave();
        Task<Giave> GetGiaveById(string maGiaVe);
        Task AddGiave(Giave giave);
        Task UpdateGiave(Giave giave);
        Task DeleteGiave(string maGiaVe);
    }

    public class GiaveRepository : IGiaveRepository
    {
        private readonly web_cinema3Context _dbContext;

        public GiaveRepository(web_cinema3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Giave>> GetAllGiave()
        {
            return await _dbContext.Giaves.ToListAsync();
        }

        public async Task<Giave> GetGiaveById(string maGiaVe)
        {
            return await _dbContext.Giaves.FindAsync(maGiaVe);
        }

        public async Task AddGiave(Giave giave)
        {
            await _dbContext.Giaves.AddAsync(giave);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGiave(Giave giave)
        {
            _dbContext.Entry(giave).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGiave(string maGiaVe)
        {
            var giave = await _dbContext.GiaveModels.FindAsync(maGiaVe);
            if (giave != null)
            {
                _dbContext.GiaveModels.Remove(giave);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}