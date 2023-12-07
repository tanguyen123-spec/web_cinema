using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class GiaVeServices : MyRepository<Giave>
    {
        private readonly web_cinema3Context _context;
        public GiaVeServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task CreatebyModels( GiaveModels giaves)
        {
            var giave = new Giave
            {
                MaGiaVe = giaves.MaGiaVe,
                TenLoaiVe = giaves.TenLoaiVe,
                GiaVe1 = giaves.GiaVe1
            };
            _context.Giaves.Add(giave);
            await _context.SaveChangesAsync();
        }
    }
}
