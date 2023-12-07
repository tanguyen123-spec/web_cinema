using System;
using System.Collections.Generic;

namespace sell_movie.Entities
{
    public partial class Theloai
    {
        public Theloai()
        {
            Phims = new HashSet<Phim>();
        }

        public string MaTl { get; set; } = null!;
        public string TenTl { get; set; } = null!;

        public virtual ICollection<Phim> Phims { get; set; }
    }
}
