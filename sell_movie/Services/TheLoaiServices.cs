using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing.Text;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Repository;

namespace sell_movie.Services
{
    public class TheLoaiServices : MyRepository<Theloai>
    {
        private readonly web_cinema3Context _context;
        public TheLoaiServices(web_cinema3Context context) : base(context) 
        {
            _context = context;
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
