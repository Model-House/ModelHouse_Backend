using backend.Register.Domain.Models;
using backend.Security.Domain.Models;
using backend.Security.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Security.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Business>> ListAsync()
    {
        return await _context.Businesses.ToListAsync();

    }

    public async Task AddAsync(Business user)
    {
        await _context.Businesses.AddAsync(user);
    }

    public async Task<Business> FindByIdAsync(long id)
    {
        return await _context.Businesses.FindAsync(id);
    }

    public async Task<Business> FindByEmailAsync(string email)
    {
        return await _context.Businesses.SingleOrDefaultAsync(x => x.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Businesses.Any(x => x.Email == email);
    }

    /*public async Task<UserX> FindByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Users.Any(x => x.Username == username);
    }*/

    public Business FindById(long id)
    {
        return _context.Businesses.Find(id);
    }

    public void Update(Business user)
    {
        _context.Businesses.Update(user);
    }

    public void Remove(Business user)
    {
        _context.Businesses.Remove(user);
    }
}