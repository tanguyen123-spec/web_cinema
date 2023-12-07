using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class TdKhachHangModels
    {
        public string Id { get; set; }
        public string Makhachhang { get; set; } = null!;
        public int? Diemkhachhang { get; set; }
        public string? HangKh { get; set; }
    }
}
