using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class TtDatVeServices : MyRepository<Ttdatve>
    {
        private readonly web_cinema3Context _context;
        public TtDatVeServices(web_cinema3Context context) : base(context) 
        {
            _context = context;
        }
        public int MaDatVe { get; set; }
        public string MaLichPhim { get; set; } = null!;
        public DateTime NgayDat { get; set; }
        public async Task CreatebyModels(TtdatveModels ttdatve)
        {
            var tt = new Ttdatve
            {
                MaDatVe = ttdatve.MaDatVe,
                MaLichPhim = ttdatve.MaLichPhim,
                NgayDat = ttdatve.NgayDat

            };
            _context.Ttdatves.Add(tt);
            await _context.SaveChangesAsync();
        }
    }
    
}
