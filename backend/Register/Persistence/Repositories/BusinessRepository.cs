using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class BusinessRepository: BaseRepository, IBusinessRepository
{
    public BusinessRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Business>> ListAsync()
    {
        return await _context.Businesses
            .ToListAsync();
    }

    public async Task<Business> FindByIdAsync(long id)
    {
        return await _context.Businesses.FindAsync(id);
    }

    public async Task AddAsync(Business business)
    {
        await _context.Businesses.AddAsync(business);
    }
    public async Task<Business> FindByEmailAsync(string email)
    {
        return await _context.Businesses
            .FirstOrDefaultAsync(p => p.Email == email);
    }

    public void Update(Business business)
    {
        _context.Businesses.Update(business);
    }
}