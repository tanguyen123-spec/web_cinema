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
    }
    
}
