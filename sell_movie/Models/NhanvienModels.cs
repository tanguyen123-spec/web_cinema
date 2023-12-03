using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class NhanvienModels
    {
      

        public string MaNhanVien { get; set; } = null!;
        public string TenNhanVien { get; set; } = null!;
        public string SoDienThoai { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public byte Gioitinh { get; set; }
        public DateTime Ngaysinh { get; set; }

       
    }
}
