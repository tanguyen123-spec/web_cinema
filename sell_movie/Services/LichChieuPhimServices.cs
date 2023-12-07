using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class LichChieuPhimServices : MyRepository<Lichchieuphim>
    {
        private readonly web_cinema3Context context_;
        public LichChieuPhimServices(web_cinema3Context context) : base(context) 
        {
            context_ = context;
        }
        public async Task CreatebyModels(LichchieuphimModels lichchieuphim)
        {
            var lcp = new Lichchieuphim
            {
                MaLichChieu = lichchieuphim.MaLichPhim,
                MaPhong = lichchieuphim.MaPhong,
                MaPhim = lichchieuphim.MaPhim
                  
    };
            context_.Lichchieuphims.Add(lcp);
            await context_.SaveChangesAsync();
        }
    }
}
