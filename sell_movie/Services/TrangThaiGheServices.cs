using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ITrangThaiGheService
    {
        Task<IEnumerable<Trangthaighe>> GetAll();
        Task<IEnumerable<TrangThaiGheModels>> Getall2();
        Task<Trangthaighe> GetById(string id);
        Task Create(Trangthaighe entity);
        Task addTTGbyModels(TrangThaiGheModels trangThai);
        Task Update(string id, Trangthaighe entity);
        Task Delete(string id);
    }
    public class TrangThaiGheServices : ITrangThaiGheService
    {
        private readonly IRepository<Trangthaighe> _repository;
        private readonly web_cinema3Context _context;
        public TrangThaiGheServices(IRepository<Trangthaighe> repository, web_cinema3Context context) 
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Trangthaighe entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Trangthaighe>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Trangthaighe> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Trangthaighe entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task addTTGbyModels(TrangThaiGheModels trangThai)
        {
            var Ttg = new Trangthaighe
            {
                Maghe = trangThai.Maghe,
                MaPhong = trangThai.MaPhong,
                MaLichChieu = trangThai.MaLichChieu,
                TrangThai = trangThai.TrangThai,
            };
            _context.Add(Ttg);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrangThaiGheModels>> Getall2()
        {
            var ttg = await _context.Trangthaighes.ToListAsync();
            return ttg.Select(trangthai => new TrangThaiGheModels 
            { 
                Maghe = trangthai.Maghe,
                MaLichChieu = trangthai.MaLichChieu,
                MaPhong = trangthai.MaPhong,
                TrangThai = trangthai.TrangThai,
            });

        }
    }
}
