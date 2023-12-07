using sell_movie.Entities;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class QuocGiaServices : MyRepository<Quocgium>
    {
        private readonly web_cinema3Context _context;
        public QuocGiaServices(web_cinema3Context context ) : base( context ) 
        {
            _context = context;
        }
    }
}
