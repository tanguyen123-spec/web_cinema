using sell_movie.Entities;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class PhimServices : MyRepository<Phim>
    {
        private readonly web_cinema3Context _context;
        public PhimServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public string GetNameofphim(string name)
        {
            var phim = (from ph in  _context.Phims where ph.TenPhim == name select ph).SingleOrDefault();
            if(phim != null)
            {
                return phim.TenPhim;
            }
            return "phim không tồn tại";
        }
    }
}
