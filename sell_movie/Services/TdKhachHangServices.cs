using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class TdKhachHangServices : MyRepository<Tdkhachhang>
    {
        private readonly web_cinema3Context _context;   
        public TdKhachHangServices( web_cinema3Context context) : base(context) 
        {
            _context = context;

        }
        public async Task Addttkh (TdKhachHangModels td)
        {
            var ttkh = new Tdkhachhang
            {
                Diemkhachhang = td.Diemkhachhang,
                HangKh = td.HangKh,
                Makhachhang = td.Makhachhang,
            };
            _context.Add(ttkh);
            await _context.SaveChangesAsync();  
        }
    }
}
