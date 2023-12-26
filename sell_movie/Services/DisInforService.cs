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
            string maLichPhim = LayMaLichPhim(disInfor);
            if (string.IsNullOrEmpty(maLichPhim))
            {
                Console.WriteLine("Không tìm thấy mã lịch chiếu phim!");
                return;
            }

            Ttdatve datVe = new Ttdatve
            {
                MaDatVe = GenerateMaDatVe(),
                NgayDat = disInfor.NgayDatVe,
                MaLichPhim = LayMaLichPhim(disInfor)
            };

            _context.Ttdatves.Add(datVe);
            _context.SaveChanges();

            int maDatVe = datVe.MaDatVe;
            var seatCodes = disInfor.MaGhe.Split(',');

            if (seatCodes.Length >= 2)
            {
                foreach (var seatCode in seatCodes)
                {
                    var existingCtdatve = _context.Ctdatves.Local.FirstOrDefault(ct => ct.MaDatVe == maDatVe && ct.MaGhe == seatCode);

                    if (existingCtdatve != null)
                    {
                        _context.Entry(existingCtdatve).State = EntityState.Detached;
                    }

                    Ctdatve ctdatve = new Ctdatve
                    {
                        MaDatVe = maDatVe,
                        MaGhe = seatCode,
                        GiaVe = 80000,
                    };

                    _context.Ctdatves.Add(ctdatve);
                }

                _context.SaveChanges();
            }
            Thanhtoan thanhtoan = new Thanhtoan
            {
                MaThanhToan = GenerateMaThanhToan(),
                MaDatVe = maDatVe, // Use the obtained MaDatVe
                MaNhanVien = "NV001",
                NgayThanhToan = disInfor.NgayDatVe,
                Phuongthucthanhtoan = disInfor.PhuongThucThanhToan,
                TongTienThanhToan = disInfor.tongtien
            };

            // Thêm thanhtoan vào DbContext và lưu vào cơ sở dữ liệu
            _context.Thanhtoans.Add(thanhtoan);
            _context.SaveChanges();
            // Tách các mã ghế thành một mảng
            string[] maGhes = disInfor.MaGhe.Split(',');

            // Duyệt qua từng mã ghế và thêm vào bảng Trangthaighe
            foreach (var maGhe in maGhes)
            {
                // Trim các khoảng trắng ở đầu và cuối mã ghế
                string trimmedMaGhe = maGhe.Trim();

                if (string.IsNullOrEmpty(trimmedMaGhe))
                    continue; // Bỏ qua mã ghế rỗng

                // Tạo đối tượng Trangthaighe và gán giá trị
                Trangthaighe trangThaiGhe = new Trangthaighe
                {
                    Maghe = trimmedMaGhe,
                    MaPhong = disInfor.MaPhong,
                    TrangThai = 1,
                    MaLichChieu = LayMaLichChieu(disInfor)
                };

                // Thêm trangThaiGhe vào DbContext và lưu vào cơ sở dữ liệu
                _context.Trangthaighes.Add(trangThaiGhe);
                _context.SaveChanges();
            }
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
    }
}



    
