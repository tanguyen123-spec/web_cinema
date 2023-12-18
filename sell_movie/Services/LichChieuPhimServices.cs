using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace sell_movie.Services
{
    public interface ILichChieuPhimService
    {
        Task<IEnumerable<Lichchieuphim>> GetAll();
        Task<Lichchieuphim> GetById(string id);
        Task<List<Ghe>> GetGheByTenPhimVaGioChieu(GeTGhemodel tGhemodel, string tenPhim, DateTime gioChieu);
        Task<List<LichChieuPhimInfo>> GetAllLichChieuPhimInfo();
        Task Create(Lichchieuphim entity);
        Task CreatebyModels(LichchieuphimModels lichchieuphim);
        Task Update(string id, Lichchieuphim entity);
        Task Delete(string id);
    }
    public class LichChieuPhimServices : ILichChieuPhimService
    {
        private readonly IRepository<Lichchieuphim> _repository;
        private readonly JsonSerializerOptions jsonOptions_;
        private readonly web_cinema3Context context_;
        public LichChieuPhimServices(IRepository<Lichchieuphim> repository, web_cinema3Context context_)
        {
            _repository = repository;
            jsonOptions_ = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            this.context_ = context_;
        }
        public async Task Create(Lichchieuphim entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Lichchieuphim>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Lichchieuphim> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Lichchieuphim entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(LichchieuphimModels lichchieuphim)
        {
            var lcp = new Lichchieuphim
            {
                MaLichChieu = lichchieuphim.MaLichChieu,
                MaLichPhim = lichchieuphim.MaLichPhim,
                MaPhong = lichchieuphim.MaPhong,
                MaPhim = lichchieuphim.MaPhim
            };

            // Kiểm tra xem giá trị lichchieuphim.MaPhong có tồn tại trong bảng "phong" hay không
            bool phongExists = await context_.Phongs.AnyAsync(p => p.MaPhong == lichchieuphim.MaPhong);

            if (phongExists)
            {
                context_.Lichchieuphims.Add(lcp);
                await context_.SaveChangesAsync();
            }
            else
            {
                // Xử lý trường hợp MaPhong không tồn tại
                // ...
            }
        }
        public async Task<List<Ghe>> GetGheByTenPhimVaGioChieu(GeTGhemodel tGhemodel, string tenPhim, DateTime gioChieu)
        {
            // Truy vấn bảng Lichchieus để lấy mã lịch chiếu dựa trên thông tin giờ chiếu và ngày chiếu
            var lichchieu =  context_.Lichchieus.FirstOrDefault(lc =>
                lc.GioChieu == new TimeSpan(tGhemodel.Gio, tGhemodel.Phut, 0));
            if (lichchieu != null)
            {
                var lichchieuPhim = context_.Lichchieuphims.FirstOrDefault(lp =>
                    lp.MaLichChieu == lichchieu.MaLichChieu && lp.MaPhimNavigation.TenPhim == tGhemodel.TenPhim);
                if (lichchieuPhim != null)
                {
                    var maPhong = lichchieuPhim.MaPhong;

                    var phong = context_.Phongs.FirstOrDefault(p => p.MaPhong == maPhong);
                    if (phong != null)
                    {
                        var maPhongGhe = phong.MaPhong;

                        var danhSachGhe = context_.Ghes.Where(g => g.MaPhong == maPhong).ToList();
                        return danhSachGhe;
                    }
                }
            }

            return new List<Ghe>(); // Trả về danh sách ghế mặc định
        }
        public async Task<List<LichChieuPhimInfo>> GetAllLichChieuPhimInfo()
        {
            var lichChieuPhims = await context_.Lichchieuphims.ToListAsync();

            var lichChieuPhimInfoList = new List<LichChieuPhimInfo>();

            foreach (var lichChieuPhim in lichChieuPhims)
            {
                var maPhim = lichChieuPhim.MaPhim;
                var maPhong = lichChieuPhim.MaPhong;

                var lichChieu = await context_.Lichchieus
                    .FirstOrDefaultAsync(lc => lc.MaLichChieu == lichChieuPhim.MaLichChieu);

                var phim = await context_.Phims
                    .FirstOrDefaultAsync(p => p.MaPhim == maPhim);

                var phong = await context_.Phongs
                    .FirstOrDefaultAsync(p => p.MaPhong == maPhong);

                if (phim != null && phong != null && lichChieu != null)
                {
                    var lichChieuPhimInfo = new LichChieuPhimInfo
                    {
                        TenPhim = phim.TenPhim,
                        GioChieu = lichChieu.GioChieu,
                        MaPhong = phong.MaPhong,
                        NgayChieu = lichChieu.NgayChieu
                    };

                    lichChieuPhimInfoList.Add(lichChieuPhimInfo);
                }
            }

            return lichChieuPhimInfoList;
        }

    }
}