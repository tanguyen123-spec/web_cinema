using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;

namespace sell_movie.Mapping
{
    public class ThanhtoanMapping:Profile
    {
        
            public ThanhtoanMapping()
            {
            CreateMap<Thanhtoan, ThanhToanModels>();
            CreateMap<ThanhToanModels, Thanhtoan>();
        }
        }
    
}
