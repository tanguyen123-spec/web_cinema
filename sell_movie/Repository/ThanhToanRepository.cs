using Microsoft.EntityFrameworkCore;
using sell_movie.Enities;

public interface IThanhtoanRepository
{
    Task<IEnumerable<Thanhtoan>> GetAllThanhtoan();
    Task<Thanhtoan> GetThanhtoanById(int id);
    Task AddThanhtoan(Thanhtoan thanhtoan);
    Task UpdateThanhtoan(Thanhtoan thanhtoan);
    Task DeleteThanhtoan(int id);
}

public class ThanhtoanRepository : IThanhtoanRepository
{
    private readonly web_cinema3Context _dbContext;

    public ThanhtoanRepository(web_cinema3Context dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Thanhtoan>> GetAllThanhtoan()
    {
        return await _dbContext.Thanhtoans.ToListAsync();
    }

    public async Task<Thanhtoan> GetThanhtoanById(int id)
    {
        return await _dbContext.Thanhtoans.FindAsync(id);
    }

    public async Task AddThanhtoan(Thanhtoan thanhtoan)
    {
        _dbContext.Thanhtoans.Add(thanhtoan);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateThanhtoan(Thanhtoan thanhtoan)
    {
        _dbContext.Entry(thanhtoan).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteThanhtoan(int id)
    {
        var thanhtoan = await _dbContext.Thanhtoans.FindAsync(id);
        if (thanhtoan != null)
        {
            _dbContext.Thanhtoans.Remove(thanhtoan);
            await _dbContext.SaveChangesAsync();
        }
    }
}
