using FranchisorTBK.Application.Interfaces;
using FranchisorTBK.Domain.Entities;

namespace FranchisorTBK.Application.Services;

public class KpiService : IKpiService
{
    private readonly IFranchiseeRepository _repository;

    public KpiService(IFranchiseeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<KpiResult>> GetKpiForFranchiseeAsync(Guid franchiseeId)
    {
        var franchisee = await _repository.GetByIdAsync(franchiseeId);
        return franchisee?.KpiResults ?? Enumerable.Empty<KpiResult>();
    }

    public async Task CalculateAndStoreKpiAsync(Franchisee franchisee)
    {
        // Dummy data — replace with QuickBooks API data in future steps
        var result = new KpiResult
        {
            Id = Guid.NewGuid(),
            FranchiseeId = franchisee.Id,
            Date = DateTime.UtcNow,
            Revenue = 100000,
            Expenses = 40000
        };

        franchisee.KpiResults.Add(result);
        await _repository.SaveChangesAsync();
    }
}
