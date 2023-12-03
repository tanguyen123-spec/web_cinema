using sell_movie.Enities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sell_movie.Repository
{
    public interface ILichchieuRepository
    {
        IEnumerable<Lichchieu> GetAll();
        Lichchieu GetById(string id);
        void Add(Lichchieu lichchieu);
        void Update(Lichchieu lichchieu);
        void Delete(string id);
    }

    public class LichchieuRepository : ILichchieuRepository
    {
        private readonly List<Lichchieu> _lichchieuList;

        public LichchieuRepository()
        {
            _lichchieuList = new List<Lichchieu>();
        }

        public IEnumerable<Lichchieu> GetAll()
        {
            return _lichchieuList;
        }

        public Lichchieu GetById(string id)
        {
            return _lichchieuList.FirstOrDefault(l => l.MaLichChieu == id);
        }

        public void Add(Lichchieu lichchieu)
        {
            _lichchieuList.Add(lichchieu);
        }

        public void Update(Lichchieu lichchieu)
        {
            var existingLichchieu = _lichchieuList.FirstOrDefault(l => l.MaLichChieu == lichchieu.MaLichChieu);
            if (existingLichchieu != null)
            {
                existingLichchieu.NgayChieu = lichchieu.NgayChieu;
                existingLichchieu.GioChieu = lichchieu.GioChieu;
            }
        }

        public void Delete(string id)
        {
            var lichchieu = _lichchieuList.FirstOrDefault(l => l.MaLichChieu == id);
            if (lichchieu != null)
            {
                _lichchieuList.Remove(lichchieu);
            }
        }
    }
}