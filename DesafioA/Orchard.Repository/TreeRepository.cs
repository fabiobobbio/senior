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
    }
}