namespace FranchisorTBK.Domain.Entities;

public class Franchisee
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;

    public string? QuickBooksCompanyId { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? TokenExpiry { get; set; }

    public ICollection<KpiResult> KpiResults { get; set; } = new List<KpiResult>();
}


