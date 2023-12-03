using System;
using System.Collections.Generic;

namespace sell_movie.Enities
{
    public partial class Thanhtoan
    {
        public string MaThanhToan { get; set; } = null!;
        public int MaDatVe { get; set; }
        public string MaNhanVien { get; set; } = null!;
        public DateTime NgayThanhToan { get; set; }
        public string Phuongthucthanhtoan { get; set; } = null!;

        public virtual Ctdatve MaDatVeNavigation { get; set; } = null!;
        public virtual Nhanvien MaNhanVienNavigation { get; set; } = null!;
    }
}
