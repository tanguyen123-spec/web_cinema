using sell_movie.Entities;
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
    }
}
