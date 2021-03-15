using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orchard.Domain.Interfaces
{
    public interface ITreeRepository : IRepository<Tree>
    {
         //Task<IEnumerable<Tree>> GetTreeById(int id);
    }
}