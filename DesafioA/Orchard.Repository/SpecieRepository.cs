using Microsoft.Extensions.Configuration;
using Orchard.Domain;
using Orchard.Domain.Interfaces;

namespace Orchard.Repository
{
    public class SpecieRepository : Repository<Specie>, ISpecieRepository
    {
        private readonly IConfiguration _configuration;

        public SpecieRepository(OrchardContext context, IConfiguration configuration) : base(context) {
            _configuration = configuration;
        }
    }
}