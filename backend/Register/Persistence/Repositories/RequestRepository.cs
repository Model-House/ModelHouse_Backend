using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Repositories;

public class RequestRepository : BaseRepository, IRequestRepository
{
    public RequestRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _context.Requests.Include(p=>p.Client).ToListAsync();
    }

    public async Task<Request> FindByIdAsync(long id)
    {
        return await _context.Requests
            .Include(p => p.Client)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Request request)
    {
        await _context.Requests.AddAsync(request);
    }
}