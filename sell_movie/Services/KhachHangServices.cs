using Microsoft.EntityFrameworkCore;
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
            var kh = new Khachhang
            {
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

            // Thêm bản ghi vào bảng "khachhang" trước
            _context.Add(kh);
            await _context.SaveChangesAsync();

            // Thêm bản ghi vào bảng "tdkhachhang" sau
            _context.Add(tdkh);
            await _context.SaveChangesAsync();

            // Xóa các bản ghi liên quan trong bảng "tdkhachhang"
            var relatedTdkh = await _context.Tdkhachhangs
                .Where(t => t.Makhachhang == kh.Makhachhang)
                .ToListAsync();

            if (relatedTdkh.Count > 0)
            {
                _context.RemoveRange(relatedTdkh);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(string id)
        {
            var khachhang = await GetById(id)
;
            if (khachhang != null)
            {
                // Xóa các bản ghi liên quan trong bảng "tdkhachhang"
                var relatedTdkh = await _context.Tdkhachhangs
                    .Where(t => t.Makhachhang == id)
                    .ToListAsync();

                if (relatedTdkh.Count > 0)
                {
                    _context.RemoveRange(relatedTdkh);
                }

                // Xóa khách hàng
                _context.Remove(khachhang);
                await _context.SaveChangesAsync();
            }
        }
    }
}