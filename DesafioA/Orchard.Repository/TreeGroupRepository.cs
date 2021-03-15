using Microsoft.Extensions.Configuration;
using Orchard.Domain;
using Orchard.Domain.Interfaces;

namespace Orchard.Repository
{
    public class TreeGroupRepository : Repository<TreeGroup>, ITreeGroupRepository
    {
        private readonly IConfiguration _configuration;

        public TreeGroupRepository(OrchardContext context, IConfiguration configuration) : base(context) {
            _configuration = configuration;
        }
    }
}