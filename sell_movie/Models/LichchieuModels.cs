using System;

namespace sell_movie.Models
{
    public class LichChieuModels
    {
        public string MaLichChieu { get; set; } = null!;
        public DateTime NgayChieu { get; set; }

        // Thêm thuộc tính cho giờ và phút chiếu của bộ phim
        public int GioChieuHour { get; set; }
        public int GioChieuMinute { get; set; }

        // Thuộc tính tích hợp để lưu trữ giờ chiếu dưới dạng TimeSpan
        public TimeSpan GioChieu
        {
            get { return new TimeSpan(GioChieuHour, GioChieuMinute, 0); }
        }
    }
}
