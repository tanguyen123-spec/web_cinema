using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sell_movie.Entities
{
    public partial class Ttdatve
    {
        [Key]
        public int MaDatVe { get; set; }
        public string MaLichPhim { get; set; } = null!;
        public DateTime NgayDat { get; set; }

        public virtual Lichchieuphim MaLichPhimNavigation { get; set; } = null!;
    }
}
