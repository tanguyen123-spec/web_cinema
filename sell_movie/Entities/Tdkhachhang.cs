using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sell_movie.Entities
{
    public partial class Tdkhachhang
    {
        [Key]
        public string Makhachhang { get; set; } = null!;
        public int? Diemkhachhang { get; set; }
        public string? HangKh { get; set; }

        public virtual Khachhang MakhachhangNavigation { get; set; } = null!;
    }
}
