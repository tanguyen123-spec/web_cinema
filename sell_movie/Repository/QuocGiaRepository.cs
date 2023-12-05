using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;

namespace sell_movie.Repository
{
    public interface IQuocGiaRepository
    {
        Task<IEnumerable<Quocgium>> GetAll();
        Task<Quocgium> GetById(string id);
        Task Add(Quocgium quocGia);
        Task Update(Quocgium quocGia);
        Task Delete(string id);
    }

    public class QuocGiaRepository : IQuocGiaRepository
    {
        private readonly web_cinema3Context _context;

        public QuocGiaRepository(web_cinema3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quocgium>> GetAll()
        {
            return await _context.Quocgium.ToListAsync();
        }

        public async Task<Quocgium> GetById(string id)
        {
            return await _context.Quocgium.FindAsync(id);
        }

        public async Task Add(Quocgium quocGia)
        {
            await _context.Quocgium.AddAsync(quocGia);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Quocgium quocGia)
        {
            _context.Quocgium.Update(quocGia);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var quocGia = await _context.Quocgium.FindAsync(id);
            if (quocGia != null)
            {
                _context.Quocgium.Remove(quocGia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
