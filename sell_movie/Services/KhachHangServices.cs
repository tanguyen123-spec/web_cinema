using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class KhachHangServices : MyRepository<Khachhang>
    {
        private readonly web_cinema3Context _context;
        public KhachHangServices(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public async Task AddByModels(KhachhangModels khachhang)
        {
            var kh = new Khachhang { 
                Makhachhang = khachhang.Makhachhang,
                Tenkhachhang = khachhang.Tenkhachhang,
                Diachi = khachhang.Diachi,
                Gioitinh = khachhang.Gioitinh,
                Sdt = khachhang.Sdt,
            };
            var tdkh = new Tdkhachhang
            {
                Diemkhachhang = 0,
                Makhachhang = kh.Makhachhang,
                HangKh = "None",
            };
            _context.Add(tdkh);
            _context.Add(kh);   
            await _context.SaveChangesAsync();
        }
    }
}
