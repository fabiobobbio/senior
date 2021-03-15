using System;
using System.Threading.Tasks;

namespace Orchard.Domain.Interfaces
{
    public interface ITreeGroupService : IDisposable
    {
        Task Add(TreeGroup treeGroup);
        Task Update(TreeGroup treeGroup);
        Task Delete(int id);
    }
}