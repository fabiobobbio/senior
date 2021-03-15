using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orchard.Domain;
using Orchard.Domain.Interfaces;

namespace Orchard.Repository
{
    public class TreeRepository : Repository<Tree>, ITreeRepository
    {
        private readonly IConfiguration _configuration;

        public TreeRepository(OrchardContext context, IConfiguration configuration) : base(context) {
            _configuration = configuration;
        }

        /*public async Task<IEnumerable<Tree>> GetTreeById(int id)
        {
            return (IEnumerable<Tree>)await Db.Trees.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }*/
    }
}