using System;
using System.Threading.Tasks;
using Orchard.Domain.Interfaces;

namespace Orchard.Domain.Services
{
  public class HarvestService : BaseService, IHarvestService
  {
    private readonly IHarvestRepository _harvestRepository;
    public HarvestService(IHarvestRepository harvestRepository,
                          INotifier notifier) : base(notifier)
    {
        _harvestRepository = harvestRepository;
    }
    public async Task Add(Harvest harvest)
    {
      await _harvestRepository.Create(harvest);
    }

    public async Task Delete(int id)
    {
      await _harvestRepository.Delete(id);
    }
    public async Task Update(Harvest harvest)
    {
      await _harvestRepository.Update(harvest);
    }

    public void Dispose()
    {
        _harvestRepository?.Dispose();
    }
  }
}