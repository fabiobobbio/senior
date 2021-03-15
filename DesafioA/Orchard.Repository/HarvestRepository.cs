using Microsoft.Extensions.Configuration;
using Orchard.Domain;
using Orchard.Domain.Interfaces;

namespace Orchard.Repository
{
    public class HarvestRepository : Repository<Harvest>, IHarvestRepository
    {
        private readonly IConfiguration _configuration;

        public HarvestRepository(OrchardContext context, IConfiguration configuration) : base(context) {
            _configuration = configuration;
        }
    }
}