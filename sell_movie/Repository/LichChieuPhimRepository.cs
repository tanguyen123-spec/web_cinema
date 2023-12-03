using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Repository
{
    public class LichChieuPhimRepository : IRepository<LichchieuphimModels>
    {
        private readonly web_cinema3Context _Cinema3Context;
        public LichChieuPhimRepository(web_cinema3Context cinema3Context)
        {
            _Cinema3Context = cinema3Context;
        }

        public async Task Create(LichchieuphimModels entity)
        {
            var Lcp = new Lichchieuphim
            {
                MaLichChieu = entity.MaLichChieu,
                MaLichPhim = entity.MaLichPhim,
                MaPhim = entity.MaPhim,
                MaPhong = entity.MaPhong, 
            };
            _Cinema3Context.Add(Lcp);
            await _Cinema3Context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var Lcp = (from lc in _Cinema3Context.Lichchieuphims where lc.MaLichPhim == id select lc).SingleOrDefault();
            if (Lcp != null)
            {
                _Cinema3Context.Remove(Lcp);
                await _Cinema3Context.SaveChangesAsync();
            }    
        }

        public async Task<IEnumerable<LichchieuphimModels>> GetAll()
        {
            var Lcp = await _Cinema3Context.Lichchieuphims.ToListAsync();
            return Lcp.Select(lc => new LichchieuphimModels
            {
                MaLichChieu = lc.MaLichChieu,
                MaLichPhim = lc.MaLichPhim,
                MaPhim = lc.MaPhim,
                MaPhong = lc.MaPhong
            });
        }

        public async Task<LichchieuphimModels> GetById(string id)
        {
            var Lcp = await _Cinema3Context.Lichchieuphims
                .Where(lc => lc.MaLichPhim == id)
                .SingleOrDefaultAsync();
            if (Lcp != null)
            {
                return new LichchieuphimModels
                {
                    MaLichChieu = Lcp.MaLichChieu,
                    MaLichPhim = Lcp.MaLichPhim,
                    MaPhim = Lcp.MaPhim,
                    MaPhong = Lcp.MaPhong
                };
            }
            return null;
        }

        public async Task Update(string id, LichchieuphimModels entity)
        {
            var Lcpexitsting =  _Cinema3Context.Lichchieuphims.SingleOrDefault(lc => lc.MaLichPhim == id);
            if (Lcpexitsting != null)
            {
                Lcpexitsting.MaLichChieu =entity.MaLichChieu;
                Lcpexitsting.MaLichPhim = entity.MaLichPhim;
                Lcpexitsting.MaPhong = entity.MaPhong;
                Lcpexitsting.MaPhim = entity.MaPhim;
                await _Cinema3Context.SaveChangesAsync();
            }
        }
    }
}
