using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sell_movie.Entities
{
    public partial class Trangthaighe
    {
        [Key]
        public string Maghe { get; set; } = null!;
        public byte TrangThai { get; set; }
        public string MaPhong { get; set; } = null!;
        public string MaLichChieu { get; set; } = null!;

        public virtual Lichchieu MaLichChieuNavigation { get; set; } = null!;
        public virtual Phong MaPhongNavigation { get; set; } = null!;
        public virtual Ghe MagheNavigation { get; set; } = null!;
    }
}
