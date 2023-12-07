using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class LichChieuServices : MyRepository<Lichchieu>
    {
        private readonly web_cinema3Context context_;
        public LichChieuServices(web_cinema3Context context) : base(context)
        {
            context_ = context;
        }
        public async Task CreatebyModels(LichchieuModels lichchieu)
        {
            var lc = new Lichchieu
            {
                 
        MaLichChieu = lichchieu.MaLichChieu,
                NgayChieu = lichchieu.NgayChieu,
                GioChieu = lichchieu.GioChieu

            };
            context_.Lichchieus.Add(lc);
            await context_.SaveChangesAsync();
        }
    }
}
