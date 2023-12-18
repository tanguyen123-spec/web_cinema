using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace sell_movie.Services
{
    public interface IPhimService
    {
        Task<IEnumerable<Phim>> GetAll();
        Task<Phim> GetById(string id);
        string GetNameOfPhim(string name);
        Task Create(Phim entity);
        Task CreateByModels(PhimModels phim);
        Task Update(string id, Phim entity);
        Task Delete(string id);
        Task<IEnumerable<GenreMovieModel>> GetGenresByMovieId();
        Task UpdateImageUrl(string maPhim, string imageUrl);



    }

    public class PhimServices : IPhimService
    {
        private readonly IRepository<Phim> _repository;
        private readonly web_cinema3Context _context;

        public PhimServices(IRepository<Phim> repository, web_cinema3Context context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Phim entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Phim>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Phim> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Phim entity)
        {
            await _repository.Update(id, entity);
        }

        public string GetNameOfPhim(string name)
        {
            var phim = _context.Phims.SingleOrDefault(ph => ph.TenPhim == name);
            if (phim != null)
            {
                return phim.TenPhim;
            }
            return "Phim không tồn tại";
        }

        public async Task CreateByModels(PhimModels phim)
        {
            var p = new Phim
            {
                MaPhim = phim.MaPhim,
                TenPhim = phim.TenPhim,
                Ngaykhoichieu = phim.Ngaykhoichieu,
                Mota = phim.Mota,
                Anh = phim.Anh,
                Trailer = phim.Trailer,
                MaTl = phim.MaTl,
                MaQuocGia = phim.MaQuocGia,
                Banner = phim.Banner,
                Thoiluong = phim.Thoiluong
            };

            _context.Phims.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreMovieModel>> GetGenresByMovieId()
        {
            var genres = from tl in _context.Theloais
                         join ptl in _context.Phims on tl.MaTl equals ptl.MaTl
                         join qg in _context.Quocgia on ptl.MaQuocGia equals qg.MaQuocgia
                         select new GenreMovieModel
                         {
                             MaTl = tl.MaTl,
                             TenTl = tl.TenTl,
                             MaPhim = ptl.MaPhim,
                             TenPhim = ptl.TenPhim,
                             Ngaykhoichieu = ptl.Ngaykhoichieu,
                             Mota = ptl.Mota,
                             Anh = ptl.Anh,
                             Trailer = ptl.Trailer,
                             MaQuocGia = ptl.MaQuocGia,
                             TenQG = qg.TenQuocGia,
                             Banner = ptl.Banner,
                             Thoiluong = ptl.Thoiluong
                         };

            return await genres.ToListAsync();
        }
        public async Task Update(string id, PhimModels phim)
        {
            var existingPhim = await _repository.GetById(id);
            if (existingPhim != null)
            {
                existingPhim.MaPhim = phim.MaPhim;
                existingPhim.TenPhim = phim.TenPhim;
                existingPhim.Ngaykhoichieu = phim.Ngaykhoichieu;
                existingPhim.Mota = phim.Mota;
                existingPhim.Anh = phim.Anh;
                existingPhim.Trailer = phim.Trailer;
                existingPhim.MaTl = phim.MaTl;
                existingPhim.MaQuocGia = phim.MaQuocGia;
                existingPhim.Banner = phim.Banner;
                existingPhim.Thoiluong = phim.Thoiluong;

                await _repository.Update(id, existingPhim);
            }
        }
        public async Task UpdateImageUrl(string maPhim, string imageUrl)
        {
            var phim = await _context.Phims.FirstOrDefaultAsync(p => p.MaPhim == maPhim);
            if (phim != null)
            {
                phim.Anh = imageUrl;
                await _context.SaveChangesAsync();
            }
        }
    }
}