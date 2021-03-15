using System;
using System.Threading.Tasks;

namespace Orchard.Domain.Interfaces
{
    public interface ITreeService : IDisposable
    {
        Task Add(Tree tree);
        Task Update(Tree tree);
        Task Delete(int id);
    }
}