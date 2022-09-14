using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class PortfolioRepository: BaseRepository, IPortfolioRepository
{
    public PortfolioRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Portfolio>> ListAsync()
    {
        return await _context.Portfolios
            .Include(p=>p.Business)
            .ToListAsync();
    }

    public async Task<Portfolio> FindByIdAsync(long id)
    {
        return await _context.Portfolios
            .Include(p=>p.Business)
            .FirstOrDefaultAsync(p=>p.Id == id);
    }

    public async Task AddAsync(Portfolio portfolio)
    {
        await _context.Portfolios.AddAsync(portfolio);
    }

    public void DeleteAsync(Portfolio portfolio)
    {
        _context.Portfolios.Remove(portfolio);
    }
}