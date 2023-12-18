using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface IDisInforService
    {
        public void ThemDatVe(DisInforModel disInfor);
        public int GenerateMaDatVe();
        public string GenerateMaThanhToan();
        public string LayMaLichPhim(DisInforModel disInfor);
        public string LayMaLichChieu(DisInforModel disInfor);
        public bool KiemTraMaGhe(string maGhe);
        public bool KiemTraTrangThaiGhe(string maGhe);
    }
    public class DisInforService : IDisInforService
    {
        private readonly web_cinema3Context _context;

        public DisInforService(web_cinema3Context context)
        {
            _context = context;
        }

        public void ThemDatVe(DisInforModel disInfor)
        {
            // Kiểm tra xem tên phim, giờ chiếu và ngày chiếu có khớp với mã lịch chiếu phim không
            string maLichPhim = LayMaLichPhim(disInfor);
            if (string.IsNullOrEmpty(maLichPhim))
            {
                Console.WriteLine("Không tìm thấy mã lịch chiếu phim!");
                return; // Kết thúc việc thêm dữ liệu
            }

            // Kiểm tra tính hợp lệ của mã ghế
            bool isMaGheValid = KiemTraMaGhe(disInfor.MaGhe);
            if (!isMaGheValid)
            {
                Console.WriteLine("Mã ghế không hợp lệ!");
                return; // Kết thúc việc thêm dữ liệu
            }

            // Kiểm tra tính hợp lệ của trạng thái ghế
            bool isTrangThaiGheValid = KiemTraTrangThaiGhe(disInfor.MaGhe);
            if (!isTrangThaiGheValid)
            {
                Console.WriteLine("Ghế đã được đặt trước đó!");
                return; // Kết thúc việc thêm dữ liệu
            }
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
            int maDatVe = datVe.MaDatVe;

            Ctdatve ctdatve = new Ctdatve
            {

                MaDatVe = maDatVe,
                MaGhe = disInfor.MaGhe,
                GiaVe = 80000,
            };
            _context.Ctdatves.Add(ctdatve);
            _context.SaveChanges();
            // Lấy lại đối tượng datVe từ cơ sở dữ liệu bằng mã đặt vé
            Ctdatve insertedDatVe = _context.Ctdatves.FirstOrDefault(dv => dv.MaDatVe == datVe.MaDatVe);

            if (insertedDatVe != null)
            {


                Thanhtoan thanhtoan = new Thanhtoan
                {
                    MaThanhToan = GenerateMaThanhToan(),
                    MaDatVe = maDatVe, // Use the obtained MaDatVe
                    MaNhanVien = "NV001",
                    NgayThanhToan = DateTime.Now,
                    Phuongthucthanhtoan = disInfor.PhuongThucThanhToan,
                };

                // Thêm thanhtoan vào DbContext và lưu vào cơ sở dữ liệu
                _context.Thanhtoans.Add(thanhtoan);
                _context.SaveChanges();
            }
           
            // Tìm đối tượng Ghe và cập nhật trạng thái
            Ghe ghe = _context.Ghes.FirstOrDefault(g => g.MaGhe == disInfor.MaGhe && g.MaPhong == disInfor.MaPhong);
            Trangthaighe ttghe = new Trangthaighe
            {
                Maghe = disInfor.MaGhe,
                MaPhong = disInfor.MaPhong,
                TrangThai = 1,
                MaLichChieu = LayMaLichChieu(disInfor)

            };
            // Thêm thanhtoan vào DbContext và lưu vào cơ sở dữ liệu
            _context.Trangthaighes.Add(ttghe);
            _context.SaveChanges();

        }

        public int GenerateMaDatVe()
        {
            Random random = new Random();
            return random.Next();
        }
        public string GenerateMaThanhToan()
        {
            Random random = new Random();
            return random.Next().ToString();
        }
        public string LayMaLichPhim(DisInforModel disInfor)
        {
            // Truy vấn bảng Phims để kiểm tra sự tồn tại của tên phim
            bool isTenPhimValid = _context.Phims.Any(p => p.TenPhim == disInfor.TenPhim);
            if (!isTenPhimValid)
            {
                Console.WriteLine("Tên phim không tồn tại!");
                return string.Empty; // Trả về chuỗi rỗng nếu tên phim không tồn tại
            }

            // Truy vấn bảng Lichchieus để lấy mã lịch chiếu dựa trên thông tin giờ chiếu và ngày chiếu
            var lichchieu = _context.Lichchieus.FirstOrDefault(lc =>
                lc.GioChieu == new TimeSpan(disInfor.Gio, disInfor.Phut, 0) && lc.NgayChieu == disInfor.NgayChieu);
            Console.WriteLine(lichchieu);
            if (lichchieu != null)
            {
                // Truy vấn bảng LichchieuPhims để lấy mã lịch phim từ mã lichchieu và kiểm tra khớp với tên phim
                var lichchieuPhim = _context.Lichchieuphims.FirstOrDefault(lp =>
                    lp.MaLichChieu == lichchieu.MaLichChieu && lp.MaPhimNavigation.TenPhim == disInfor.TenPhim);
                if (lichchieuPhim != null)
                {
                    return lichchieuPhim.MaLichPhim.ToString();
                }
            }

            // Trả về chuỗi rỗng hoặc một giá trị biểu thị rằng không tìm thấy mã lịch phim
            return string.Empty;
        }
        public string LayMaLichChieu(DisInforModel disInfor)
        {
            // Truy vấn bảng Phims để kiểm tra sự tồn tại của tên phim
            bool isTenPhimValid = _context.Phims.Any(p => p.TenPhim == disInfor.TenPhim);
            if (!isTenPhimValid)
            {
                Console.WriteLine("Tên phim không tồn tại!");
                return string.Empty; // Trả về chuỗi rỗng nếu tên phim không tồn tại
            }

            // Truy vấn bảng Lichchieus để lấy mã lịch chiếu dựa trên thông tin giờ chiếu và ngày chiếu
            var lichchieu = _context.Lichchieus.FirstOrDefault(lc =>
                lc.GioChieu == new TimeSpan(disInfor.Gio, disInfor.Phut, 0) && lc.NgayChieu == disInfor.NgayChieu);
            Console.WriteLine(lichchieu);
            if (lichchieu != null)
            {
               
               
                    return lichchieu.MaLichChieu.ToString();
               
            }

            // Trả về chuỗi rỗng hoặc một giá trị biểu thị rằng không tìm thấy mã lịch phim
            return string.Empty;
        }
        public bool KiemTraMaGhe(string maGhe)
        {
            // Kiểm tra xem mã ghế có tồn tại trong bảng Ghế hay không
            bool isMaGheValid = _context.Ghes.Any(g => g.MaGhe == maGhe);
            return isMaGheValid;
        }

        public bool KiemTraTrangThaiGhe(string maGhe)
        {
            // Kiểm tra xem mã ghế có tồn tại trong bảng Trangthaighes và có trạng thái "Đã đặt" hay không
            bool isTrangThaiGheValid = _context.Trangthaighes.Any(t => t.Maghe == maGhe && t.TrangThai == 1);
            return !isTrangThaiGheValid; // Trả về true nếu mã ghế không có trạng thái "Đã đặt"
        }

    }
}