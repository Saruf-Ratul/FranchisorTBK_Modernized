namespace FranchisorTBK.Domain.Entities;

public class KpiResult
{
    public Guid Id { get; set; }
    public Guid FranchiseeId { get; set; }
    public Franchisee Franchisee { get; set; } = null!;
    public DateTime Date { get; set; }
    public decimal Revenue { get; set; }
    public decimal Expenses { get; set; }
    public decimal Profit => Revenue - Expenses;
}
