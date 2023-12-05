using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;

namespace sell_movie.Mapping
{
    public class TrangThaiGheMapping:Profile
    {
        public TrangThaiGheMapping()
        {
            CreateMap<Trangthaighe, TrangThaiGheModels>();
            CreateMap<TrangThaiGheModels, Trangthaighe>();
        }
    }
}
