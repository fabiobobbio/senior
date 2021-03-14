using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Orchard.Repository.Interfaces;

namespace Orchard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : MainController
    {
        private readonly IMapper _mapper;
        public SpeciesController(IMapper mapper, INotifier notifier) : base(notifier)
        {
            
        }
    }
}