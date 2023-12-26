using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sell_movie.Entities
{
    public partial class Ctdatve
    {
       
        
        public int MaDatVe { get; set; }
        
        public string MaGhe { get; set; } = null!;
        public int GiaVe { get; set; }

        public virtual Ghe MaGheNavigation { get; set; } = null!;
        public virtual Ttdatve ttdatveNavigation { get; set; } = null!;



    }
}
