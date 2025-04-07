using FranchisorTBK.Domain.Entities;

namespace FranchisorTBK.Application.Interfaces;

public interface IKpiService
{
    Task<IEnumerable<KpiResult>> GetKpiForFranchiseeAsync(Guid franchiseeId);
    Task CalculateAndStoreKpiAsync(Franchisee franchisee);
}
