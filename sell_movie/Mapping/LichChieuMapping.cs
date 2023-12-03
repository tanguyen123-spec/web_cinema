using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;

namespace sell_movie.Mapping
{
    public class LichChieuMapping:Profile
    {
        public LichChieuMapping()
        {
            CreateMap<Lichchieu, LichchieuModels>();
            CreateMap<LichchieuModels, Lichchieu>(); 
        }
    }
}
