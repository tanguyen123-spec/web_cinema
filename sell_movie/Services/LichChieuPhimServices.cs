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
        //public string GetTenPhim(string name)
        //{
        //    var Ten = ()
        //}
    }
}
