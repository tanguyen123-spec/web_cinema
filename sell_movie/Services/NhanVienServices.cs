using sell_movie.Entities;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class NhanVienServices : MyRepository<Nhanvien>
    {
        private readonly web_cinema3Context context_;
        public NhanVienServices(web_cinema3Context context) : base(context)
        {
            context_ = context;
        }
    }
}
