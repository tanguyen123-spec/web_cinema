using System.Collections.Generic;
using sell_movie.Repository;
using sell_movie.Enities;


namespace sell_movie.Services
{
    public interface IKhachhangService
    {
        IEnumerable<Khachhang> GetAllKhachhang();
        Khachhang GetKhachhangById(string id);
        void AddKhachhang(Khachhang khachhang);
        void UpdateKhachhang(Khachhang khachhang);
        void DeleteKhachhang(string id);
    }
    public class KhachhangService : IKhachhangService
    {
        private readonly IKhachhangRepository _khachhangRepository;

        public KhachhangService(IKhachhangRepository khachhangRepository)
        {
            _khachhangRepository = khachhangRepository;
        }

        public IEnumerable<Khachhang> GetAllKhachhang()
        {
            return _khachhangRepository.GetAll();
        }

        public Khachhang GetKhachhangById(string id)
        {
            return _khachhangRepository.GetById(id);
        }

        public void AddKhachhang(Khachhang khachhang)
        {
            _khachhangRepository.Add(khachhang);
        }

        public void UpdateKhachhang(Khachhang khachhang)
        {
            _khachhangRepository.Update(khachhang);
        }

        public void DeleteKhachhang(string id)
        {
            _khachhangRepository.Delete(id);
        }
    }
}