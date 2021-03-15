using System.Threading.Tasks;
using Orchard.Domain.Interfaces;
using Orchard.Repository.Notifications;

namespace Orchard.Domain.Services
{
  public class SpecieService : BaseService, ISpecieService
  {
    private readonly ISpecieRepository _specieRepository;

    public SpecieService(ISpecieRepository specieRepository,
                         INotifier notifier) : base(notifier)
    {
        _specieRepository = specieRepository;
    }
    public async Task Add(Specie specie)
    {
      await _specieRepository.Create(specie);
    }

    public async Task Delete(int id)
    {
      await _specieRepository.Delete(id);
    }

    public async Task Update(Specie specie)
    {
      await _specieRepository.Update(specie);
    }

    public void Dispose()
    {
      _specieRepository?.Dispose();
    }
  }
}