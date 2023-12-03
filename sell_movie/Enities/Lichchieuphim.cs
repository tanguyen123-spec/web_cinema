using System;
using System.Collections.Generic;

namespace sell_movie.Enities
{
    public partial class Lichchieuphim
    {
        public Lichchieuphim()
        {
            Ttdatves = new HashSet<Ttdatve>();
        }

        public string MaLichPhim { get; set; } = null!;
        public string MaLichChieu { get; set; } = null!;
        public string MaPhong { get; set; } = null!;
        public string MaPhim { get; set; } = null!;

        public virtual Lichchieu MaLichChieuNavigation { get; set; } = null!;
        public virtual Phim MaPhimNavigation { get; set; } = null!;
        public virtual Phong MaPhongNavigation { get; set; } = null!;
        public virtual ICollection<Ttdatve> Ttdatves { get; set; }
    }
}
