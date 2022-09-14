using backend.Register.Domain.Models;
using backend.Security.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Security.Persistence.Repositories;

public class ClientProfileRepository: BaseRepository, IClientProfileRepository
{
    public ClientProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task AddAsync(Client user)
    {
        await _context.Clients.AddAsync(user);
    }

    public async Task<Client> FindByIdAsync(long id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client> FindByEmailAsync(string email)
    {
        return await _context.Clients.SingleOrDefaultAsync(x => x.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Clients.Any(x => x.Email == email);
    }
    public Client FindById(long id)
    {
        return _context.Clients.Find(id);
    }

    public void Update(Client user)
    {
        _context.Clients.Update(user);
    }

    public void Remove(Client user)
    {
        _context.Clients.Remove(user);
    }
}