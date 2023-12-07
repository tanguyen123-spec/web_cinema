using System;
using System.Collections.Generic;
using sell_movie.Entities;

namespace sell_movie.Models
{
    public partial class PhongModels
    {
       
        public string MaPhong { get; set; } = null!;
        public string TenPhong { get; set; } = null!;
        public int SoChoNgoi { get; set; }
        public int SoHang { get; set; }
        public int Socot { get; set; }
    }
}
