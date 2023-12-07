using sell_movie.Entities;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class NguoiDungServices : MyRepository<Nguoidung>
    {
        private readonly web_cinema3Context context_;

        public NguoiDungServices(web_cinema3Context context) : base(context)
        {
            context_ = context;
        }
    }
    
}
