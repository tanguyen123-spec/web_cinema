using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public interface ICtDatVeService
    {
        Task<IEnumerable<Ctdatve>> GetAll();
        Task<Ctdatve> GetById(string id);
        Task Create(Ctdatve entity);
        Task CreatebyModels(CtdatveModels ctdatve);
        Task Update(string id, Ctdatve entity);
        Task Delete(string id);
        Task<CtdatveDtocs> GetByMaDatVe(int maDatVe);
    }
    public class Ctdatveservice : ICtDatVeService
    {
        private readonly IRepository<Ctdatve> _repository;
        private readonly web_cinema3Context _context;
        public Ctdatveservice(IRepository<Ctdatve> repository, web_cinema3Context context) 
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(Ctdatve entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Ctdatve>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Ctdatve> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(string id, Ctdatve entity)
        {
             await _repository.Update(id, entity);
        }
        public async Task CreatebyModels(CtdatveModels ctdatve)
        {
            var ct = new Ctdatve
            {
                GiaVe = ctdatve.GiaVe,
                MaDatVe = ctdatve.MaDatVe,
                MaGhe = ctdatve.MaGhe
            };
            _context.Ctdatves.Add(ct);
            await _context.SaveChangesAsync();
        }
        public async Task<CtdatveDtocs> GetByMaDatVe(int maDatVe)
        {
            var ctdatve = await _context.Ctdatves.FirstOrDefaultAsync(ct => ct.MaDatVe == maDatVe);

            if (ctdatve == null)
            {
                return null;
            }

            var ctdatveDto = new CtdatveDtocs
            {
                MaDatVe = ctdatve.MaDatVe,
                MaGhe = ctdatve.MaGhe,
                GiaVe = ctdatve.GiaVe
            };

            return ctdatveDto;
        }
    }
}
