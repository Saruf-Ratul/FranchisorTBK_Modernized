// File: FranchisorTBK.Application/Interfaces/IFranchiseeRepository.cs
using FranchisorTBK.Domain.Entities;
using FranchisorTBK.Application.Interfaces;

namespace FranchisorTBK.Application.Interfaces;

public interface IFranchiseeRepository
{
    Task<IEnumerable<Franchisee>> GetAllAsync();
    Task<Franchisee?> GetByIdAsync(Guid id);
    Task AddAsync(Franchisee franchisee);
    Task SaveChangesAsync();
}