using System;
using System.Collections.Generic;

namespace sell_movie.Enities
{
    public partial class Ttdatve
    {
        public int MaDatVe { get; set; }
        public string MaLichPhim { get; set; } = null!;
        public DateTime NgayDat { get; set; }

        public virtual Lichchieuphim MaLichPhimNavigation { get; set; } = null!;
    }
}
