using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;

namespace sell_movie.Models
{
    public partial class KhachhangModels
    {
        [Name("Makhachhang")]
        public string Makhachhang { get; set; }

        [Name(" Tenkhachhang")]
        public string Tenkhachhang { get; set; }

        [Name(" Diachi")]
        public string Diachi { get; set; }

        [Name(" Gioitinh")]
        public bool Gioitinh { get; set; }

        [Name(" Sdt")]
        public string Sdt { get; set; }
    }
}
