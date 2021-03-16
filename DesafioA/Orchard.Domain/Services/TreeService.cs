using System;
using System.Threading.Tasks;
using Orchard.Domain.Interfaces;

namespace Orchard.Domain.Services
{
    public class TreeService : BaseService, ITreeService
{
    private readonly ITreeRepository _treeRepository;

    public TreeService(ITreeRepository treeRepository, INotifier notifier) : base(notifier)
    {
        _treeRepository = treeRepository;
    }

    public async Task Add(Tree tree)
    {
      try{await _treeRepository.Create(tree);}
      catch(Exception e){
        throw;
      }
    }

    public async Task Delete(int id)
    {
      await _treeRepository.Delete(id);
    }

    public async Task Update(Tree tree)
    {
      await _treeRepository.Update(tree);
    }

    public void Dispose()
    {
      _treeRepository.Dispose();
    }
  }
}