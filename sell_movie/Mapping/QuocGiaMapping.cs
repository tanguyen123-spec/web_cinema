using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;

namespace sell_movie.Mapping
{
    public class QuocGiaMapping:Profile
    {
        public QuocGiaMapping()
        {
            CreateMap<Quocgium, QuocGiaModels>();
            CreateMap<QuocGiaModels, Quocgium>();
        }
    }
}
