using sell_movie.Models;
using System;
using System.Collections.Generic;

namespace sell_movie.Entities
{
    public partial class Phim
    {
        public Phim()
        {
            Lichchieuphims = new HashSet<Lichchieuphim>();
        }

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

        public virtual Quocgium MaQuocGiaNavigation { get; set; } = null!;
        public virtual Theloai MaTlNavigation { get; set; } = null!;
        public virtual ICollection<Lichchieuphim> Lichchieuphims { get; set; }
      


    }
}
