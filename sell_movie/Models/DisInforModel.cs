namespace sell_movie.Models
{
    public class DisInforModel
    {
        public DateTime NgayDatVe { get; set; }
        public string TenPhim { get; set; }
        public DateTime NgayChieu { get; set; }
        public int Gio { get; set; }
        public int Phut { get; set; }

        public TimeSpan GioChieu
        {
            get { return new TimeSpan(Gio, Phut, 0); }
        }
        public string MaPhong { get; set; }
        public int SoLuong { get; set; }
        public string MaGhe { get; set; }
        public string PhuongThucThanhToan { get; set; }

        public DisInforModel()
        {
            NgayDatVe = DateTime.Now;
        }
    }
}