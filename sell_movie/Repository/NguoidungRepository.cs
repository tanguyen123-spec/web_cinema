using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

namespace Sell_movie_ticket.Repository
{
    public class NguoidungRepository : IRepository<NguoidungModels>
    {
        private readonly web_cinema3Context _context;

        public NguoidungRepository(web_cinema3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NguoidungModels>> GetAll()
        {
            var nguoidungs = await _context.Nguoidungs.ToListAsync();
            return nguoidungs.Select(nguoidung => new NguoidungModels
            {
                Username = nguoidung.Username,
                Password = nguoidung.Password,
                Email = nguoidung.Email,
                Role = nguoidung.Role,
                MaNhanVien = nguoidung.MaNhanVien,
            });
        }

        public async Task<NguoidungModels> GetById(string username)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(username);
            if (nguoidung != null)
            {
                return new NguoidungModels
                {
                    Username = nguoidung.Username,
                    Password = nguoidung.Password,
                    Email = nguoidung.Email,
                    Role = nguoidung.Role,
                    MaNhanVien = nguoidung.MaNhanVien,
                };
            }
            return null;
        }

        public async Task Create(NguoidungModels entity)
        {
            var nguoidung = new Nguoidung
            {
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email,
                Role = entity.Role,
                MaNhanVien = entity.MaNhanVien,
            };

            _context.Nguoidungs.Add(nguoidung);
            await _context.SaveChangesAsync();
        }

        public async Task Update(string username, NguoidungModels entity)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(username);
            if (nguoidung != null)
            {
                nguoidung.Username = entity.Username;
                nguoidung.Password = entity.Password;
                nguoidung.Email = entity.Email;
                nguoidung.Role = entity.Role;
                nguoidung.MaNhanVien = entity.MaNhanVien;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(string username)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(username);
            if (nguoidung != null)
            {
                _context.Nguoidungs.Remove(nguoidung);
                await _context.SaveChangesAsync();
            }
        }
    }
}
