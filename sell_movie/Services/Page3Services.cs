using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class Page3Services 
    {
        Page3Models page_;
        LichChieuPhimServices lichChieuPhimService_;
        private readonly PhimServices phimServices_;
        public Page3Services(Page3Models page, PhimServices phimServices) 
        { 
            page_ = page;
            phimServices_ = phimServices;
        }
        public string AddNamePhim(string n)
        {
            var name = phimServices_.GetNameofphim(n);
            return name;
        }
        
    }
}
