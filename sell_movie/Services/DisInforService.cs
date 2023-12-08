using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class DisInforService : MyRepository<DisInforModel>
    {
        private readonly web_cinema3Context _context;

        public DisInforService(web_cinema3Context context) : base(context)
        {
            _context = context;
        }
        public void ThemDatVe(DisInforModel disInfor)
        {

            // Tạo một đối tượng mới Ttdatve và gán giá trị từ disInforModel
            Ttdatve datVe = new Ttdatve
            {
                MaDatVe = GenerateMaDatVe(), // Tự tạo mã đặt vé
                NgayDat = DateTime.Now, // Ngày hiện tại
                MaLichPhim = LayMaLichPhim(disInfor) // Lấy mã lịch phim từ disInforModel
            };
            // Thêm datVe vào DbContext và lưu vào cơ sở dữ liệu
            _context.Ttdatves.Add(datVe);
            _context.SaveChanges();
            Thanhtoan thanhtoan = new Thanhtoan
            {
                MaThanhToan = GenerateMaThanhToan(),
                MaDatVe = datVe.MaDatVe,
                NgayThanhToan = DateTime.Now,
                Phuongthucthanhtoan=disInfor.PhuongThucThanhToan,
            };
            // Thêm datVe vào DbContext và lưu vào cơ sở dữ liệu
            _context.Thanhtoans.Add(thanhtoan);
            _context.SaveChanges();
        }
        private int GenerateMaDatVe()
        {
            Random random = new Random();
            return random.Next();
        }
        private string GenerateMaThanhToan()
        {
            Random random = new Random();
            return random.Next().ToString();
        }
        public string LayMaLichPhim(DisInforModel disInfor)
        {
            // Truy vấn bảng Lichchieus để lấy mã lịch chiếu dựa trên thông tin giờ chiếu và ngày chiếu
            var lichchieu = _context.Lichchieus.FirstOrDefault(lc =>
                lc.GioChieu ==  new TimeSpan(disInfor.Gio, disInfor.Phut, 0) && lc.NgayChieu == disInfor.NgayChieu);
            Console.WriteLine(lichchieu);
            if (lichchieu != null)
            {
                // Truy vấn bảng LichchieuPhims để lấy mã lịch phim từ mã lichchieu
                var lichchieuPhim = _context.Lichchieuphims.FirstOrDefault(lp => lp.MaLichChieu == lichchieu.MaLichChieu);
                if (lichchieuPhim != null)
                {
                    return lichchieuPhim.MaLichPhim.ToString();
                }
            }

            // Trả về chuỗi rỗng hoặc một giá trị biểu thị rằng không tìm thấy mã lịch phim
            return string.Empty;
        }
       


    }
}