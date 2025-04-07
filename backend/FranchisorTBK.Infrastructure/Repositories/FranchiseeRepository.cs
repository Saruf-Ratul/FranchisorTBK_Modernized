using FranchisorTBK.Domain.Entities;
using FranchisorTBK.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FranchisorTBK.Application.Interfaces; // ? Correct this namespace


namespace FranchisorTBK.Infrastructure.Repositories;

public class FranchiseeRepository : IFranchiseeRepository
{
    private readonly FranchisorDbContext _context;

    public FranchiseeRepository(FranchisorDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Franchisee>> GetAllAsync()
    {
        return await _context.Franchisees.Include(f => f.KpiResults).ToListAsync();
    }



    public async Task<Franchisee?> GetByIdAsync(Guid id) =>
        await _context.Franchisees.Include(f => f.KpiResults)
                                  .FirstOrDefaultAsync(f => f.Id == id);

    public async Task AddAsync(Franchisee franchisee)
    {
        await _context.Franchisees.AddAsync(franchisee);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
