using AutoMapper;
using sell_movie.Enities;
using sell_movie.Models;

namespace sell_movie.Mapping
{
    public class TdKhachHangmapping:Profile
    {
        public TdKhachHangmapping()
        {
            CreateMap<Tdkhachhang, TdKhachHangModels>();
            CreateMap<TdKhachHangModels, Tdkhachhang>();
        }
    }
}
