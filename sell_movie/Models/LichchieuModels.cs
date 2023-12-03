using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class LichchieuModels
    {
     

        public string MaLichChieu { get; set; } = null!;
        public DateTime NgayChieu { get; set; }
        public TimeSpan GioChieu { get; set; }

      
    }
}
