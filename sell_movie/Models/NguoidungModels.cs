using System;
using System.Collections.Generic;
using sell_movie.Entities;

namespace sell_movie.Models
{
    public partial class NguoidungModels
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Role { get; set; }
        public string MaNhanVien { get; set; } = null!; 
    }
}
