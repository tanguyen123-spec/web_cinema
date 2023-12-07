using sell_movie.Entities;
using sell_movie.Models;
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
        public string MaQuocgia { get; set; } = null!;
        public string TenQuocGia { get; set; } = null!;
        public async Task CreatebyModels(QuocGiaModels quocgia)
        {
            var qg = new Quocgium
            {
                MaQuocgia = quocgia.MaQuocgia,
                TenQuocGia = quocgia.TenQuocGia,
               
            };
            _context.Quocgia.Add(qg);
            await _context.SaveChangesAsync();
        }
    }
}
