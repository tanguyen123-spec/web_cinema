using System.Collections.Generic;
using sell_movie.Enities;

namespace sell_movie.Repository
{
    public interface IKhachhangRepository
    {
        IEnumerable<Khachhang> GetAll();
        Khachhang GetById(string id);
        void Add(Khachhang khachhang);
        void Update(Khachhang khachhang);
        void Delete(string id);
    }
    public class KhachhangRepository : IKhachhangRepository
    {
        private readonly web_cinema3Context _dbContext;

        public KhachhangRepository(web_cinema3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Khachhang> GetAll()
        {
            return _dbContext.Khachhangs.ToList();
        }

        public Khachhang GetById(string id)
        {
            return _dbContext.Khachhangs.Find(id);
        }

        public void Add(Khachhang khachhang)
        {
            _dbContext.Khachhangs.Add(khachhang);
            _dbContext.SaveChanges();
        }

        public void Update(Khachhang khachhang)
        {
            _dbContext.Khachhangs.Update(khachhang);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var khachhang = _dbContext.Khachhangs.Find(id);
            if (khachhang != null)
            {
                _dbContext.Khachhangs.Remove(khachhang);
                _dbContext.SaveChanges();
            }
        }
    }
}