using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Repository
{
    public class TtDatVeRepository : IRepository<TtdatveModels>
    {
        private readonly web_cinema3Context _context;
        public TtDatVeRepository(web_cinema3Context context)
        {
            _context = context;
        }
        public async Task Create(TtdatveModels ttdatve)
        {
            var ttdv = new Ttdatve
            {
                MaDatVe = ttdatve.MaDatVe,
                MaLichPhim = ttdatve.MaLichPhim,
                NgayDat = ttdatve.NgayDat,
            };
            _context.Add(ttdv);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var ttdv = (from tt in _context.Ttdatves where tt.MaDatVe.ToString() == id select tt).FirstOrDefault();
            if (ttdv != null)
            {
                _context.Remove(ttdv);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TtdatveModels>> GetAll()
        {
            //hàm tolistAsync trả về một List
            var tt = await _context.Ttdatves.ToListAsync();
            return tt.Select(tt => new TtdatveModels
            {
                MaDatVe = tt.MaDatVe,
                MaLichPhim = tt.MaLichPhim,
                NgayDat = tt.NgayDat
            });
        }

        public async Task<TtdatveModels> GetById(string id)
        {
            var ttDatVe = (from tt in _context.Ttdatves where tt.MaDatVe.ToString() == id select tt).SingleOrDefault();
            if(ttDatVe != null)
            {
                return new TtdatveModels
                {
                    MaDatVe = ttDatVe.MaDatVe,
                    MaLichPhim = ttDatVe.MaLichPhim,
                    NgayDat = ttDatVe.NgayDat,
                };
            }
            return null;
        }

        public async Task Update(string id, TtdatveModels entity)
        {
            var ttDatve = (from tt in _context.Ttdatves where tt.MaDatVe.ToString() != id select tt).SingleOrDefault();
            if (ttDatve != null)
            {
                ttDatve.MaDatVe = entity.MaDatVe;
                ttDatve.MaLichPhim = entity.MaLichPhim;
                ttDatve.NgayDat = entity.NgayDat;
                await _context.SaveChangesAsync();
            }    
        }
    }
}
