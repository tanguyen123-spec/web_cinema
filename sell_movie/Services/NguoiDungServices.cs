using sell_movie.Entities;
using sell_movie.Models;
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
        public async Task CreatebyModels(NguoidungModels nguoidung)
        {
        var nd = new Nguoidung
            {

            Username = nguoidung.Username,
            Password = nguoidung.Password,
            Email = nguoidung.Email,
            Role = nguoidung.Role,
            MaNhanVien = nguoidung.MaNhanVien,
           

        };
            context_.Nguoidungs.Add(nd);
            await context_.SaveChangesAsync();
        }
    }
    
}
