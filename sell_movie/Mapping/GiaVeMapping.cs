using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;

namespace sell_movie.Mapping
{
    public class GiaVeMapping : Profile
    {
        public GiaVeMapping()
        {
            CreateMap<GiaveModels, Giave>(); // Map GiaveModels to Giave
            CreateMap<Giave, GiaveModels>(); // Map Giave to GiaveModels
        }
    }
}
