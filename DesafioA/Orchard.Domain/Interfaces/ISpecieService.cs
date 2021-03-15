using System;
using System.Threading.Tasks;

namespace Orchard.Domain.Interfaces
{
    public interface ISpecieService : IDisposable
    {
        Task Add(Specie specie);
        Task Update(Specie specie);
        Task Delete(int id);
    }
}