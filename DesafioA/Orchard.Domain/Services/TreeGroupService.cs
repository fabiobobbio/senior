using System.Threading.Tasks;
using Orchard.Domain.Interfaces;

namespace Orchard.Domain.Services
{
  public class TreeGroupService : BaseService, ITreeGroupService
  {
    private readonly ITreeGroupRepository _treeGroupRepository;

    public TreeGroupService(ITreeGroupRepository treeGroupRepository,
                            INotifier notifier) : base(notifier)
    {
        _treeGroupRepository = treeGroupRepository;
    }
    public async Task Add(TreeGroup treeGroup)
    {
      await _treeGroupRepository.Create(treeGroup);
    }

    public async Task Delete(int id)
    {
      await _treeGroupRepository.Delete(id);
    }

    public async Task Update(TreeGroup treeGroup)
    {
      await _treeGroupRepository.Update(treeGroup);
    }
    public void Dispose()
    {
      _treeGroupRepository?.Dispose();
    }
  }
}