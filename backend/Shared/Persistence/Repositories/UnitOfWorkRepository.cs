using backend.Shared.Domain.Repositories;
using backend.Shared.Persistence.Contexts;

namespace backend.Shared.Persistence.Repositories;

public class UnitOfWorkRepository: IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWorkRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}