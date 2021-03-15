using System;
using System.Threading.Tasks;

namespace Orchard.Domain.Interfaces
{
    public interface IHarvestService : IDisposable
    {
        Task Add(Harvest harvest);
        Task Update(Harvest harvest);
        Task Delete(int id);
    }
}