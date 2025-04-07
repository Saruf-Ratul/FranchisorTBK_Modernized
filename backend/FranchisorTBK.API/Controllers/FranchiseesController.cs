using FranchisorTBK.Application.Interfaces;
using FranchisorTBK.Domain.Entities;
using FranchisorTBK.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FranchisorTBK.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FranchiseesController : ControllerBase
{
    private readonly IFranchiseeRepository _repository;
    private readonly IKpiService _kpiService;

    public FranchiseesController(IFranchiseeRepository repository, IKpiService kpiService)
    {
        _repository = repository;
        _kpiService = kpiService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Franchisee>>> GetAll()
    {
        var data = await _repository.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id:guid}/kpis")]
    public async Task<ActionResult<IEnumerable<KpiResult>>> GetKpis(Guid id)
    {
        var kpis = await _kpiService.GetKpiForFranchiseeAsync(id);
        return Ok(kpis);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Franchisee franchisee)
    {
        franchisee.Id = Guid.NewGuid();
        await _repository.AddAsync(franchisee);
        await _repository.SaveChangesAsync();

        await _kpiService.CalculateAndStoreKpiAsync(franchisee); // generate dummy KPI

        return CreatedAtAction(nameof(GetAll), new { id = franchisee.Id }, franchisee);
    }
}
