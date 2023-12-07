using System;
using System.Collections.Generic;

namespace sell_movie.Entities
{
    public partial class Nguoidung
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Role { get; set; }
        public string MaNhanVien { get; set; } = null!;

        public virtual Nhanvien MaNhanVienNavigation { get; set; } = null!;
    }
}
