using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sell_movie.Entities
{
    public partial class Ctdatve
    {
        public Ctdatve()
        {
            Thanhtoans = new HashSet<Thanhtoan>();
        }

        [Key]
        public int MaDatVe { get; set; }
        public string MaGhe { get; set; } = null!;
        public int GiaVe { get; set; }

        public virtual Ghe MaGheNavigation { get; set; } = null!;
        public virtual ICollection<Thanhtoan> Thanhtoans { get; set; }
    }
}
