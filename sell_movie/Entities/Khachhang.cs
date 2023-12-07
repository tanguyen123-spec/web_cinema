using System;
using System.Collections.Generic;

namespace sell_movie.Entities
{
    public partial class Khachhang
    {
        public string Makhachhang { get; set; } = null!;
        public string Tenkhachhang { get; set; } = null!;
        public string Diachi { get; set; } = null!;
        public bool Gioitinh { get; set; }
        public string Sdt { get; set; } = null!;
    }
}
