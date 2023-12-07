using System;
using System.Collections.Generic;

namespace sell_movie.Entities
{
    public partial class Lichchieu
    {
        public Lichchieu()
        {
            Lichchieuphims = new HashSet<Lichchieuphim>();
        }

        public string MaLichChieu { get; set; } = null!;
        public DateTime NgayChieu { get; set; }
        public TimeSpan GioChieu { get; set; }

        public virtual ICollection<Lichchieuphim> Lichchieuphims { get; set; }
    }
}
