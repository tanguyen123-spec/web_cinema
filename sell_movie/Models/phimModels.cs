using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class PhimModels
    {
        public string MaPhim { get; set; } = null!;
        public string TenPhim { get; set; } = null!;
        public DateTime Ngaykhoichieu { get; set; }
        public string Mota { get; set; } = null!;
        public string Anh { get; set; } = null!;
        public string Trailer { get; set; } = null!;
        public string MaTl { get; set; } = null!;
        public string MaQuocGia { get; set; } = null!;
        public string Banner { get; set; } = null!;
        public int Thoiluong { get; set; }
    }
}
