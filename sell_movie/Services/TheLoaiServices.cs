using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing.Text;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ITheLoaiService
    {
        Task<IEnumerable<Theloai>> GetAll();
        Task<IEnumerable<TheloaiModels>> GetAll2();
        Task<Theloai> GetById(string id);
        Task Create(Theloai entity);
        Task CreatebyModels(TheloaiModels theloai);
        Task Update(string id, Theloai entity);
        Task Delete(string id);
    }
    public class TheLoaiServices : ITheLoaiService
    {
        private readonly IRepository<Theloai> _repository;
        private readonly web_cinema3Context _context;
        public TheLoaiServices(IRepository<Theloai> repository, web_cinema3Context context) 
        {
            _repository = repository;
            _context = context;
        }
        public async Task Create(Theloai entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Theloai>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Theloai> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Theloai entity)
        {
            await _repository.Update(id, entity);
        }
        public async Task<IEnumerable<TheloaiModels>> GetAll2()
        {
            var theloai = await _context.Theloais.ToListAsync();
            return theloai.Select(tl => new TheloaiModels
            {
                MaTl = tl.MaTl,
                TenTl = tl.TenTl,
            });
        }
        public async Task CreatebyModels(TheloaiModels theloai)
        {
            var qg = new Theloai
            {
                MaTl = theloai.MaTl,
                TenTl = theloai.TenTl,

            };
            _context.Theloais.Add(qg);
            await _context.SaveChangesAsync();
        }

    }
}
