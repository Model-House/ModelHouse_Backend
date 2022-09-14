using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class ClientRepository: BaseRepository, IClientRepository
{

    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> FindByIdAsync(long id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task<Client> FindByEmailAsync(string email)
    {
        return await _context.Clients
            .FirstOrDefaultAsync(p => p.Email == email);
    }

    public void Update(Client client)
    {
        _context.Clients.Update(client);
    }
}