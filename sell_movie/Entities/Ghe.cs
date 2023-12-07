using System;
using System.Collections.Generic;

namespace sell_movie.Entities
{
    public partial class Ghe
    {
        public Ghe()
        {
            Ctdatves = new HashSet<Ctdatve>();
        }

        public string MaGhe { get; set; } = null!;
        public string TenGhe { get; set; } = null!;
        public string MaPhong { get; set; } = null!;

        public virtual Phong MaPhongNavigation { get; set; } = null!;
        public virtual ICollection<Ctdatve> Ctdatves { get; set; }
    }
}
