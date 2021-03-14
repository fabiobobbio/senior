using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Orchard.Repository.Interfaces;

namespace Orchard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestController : MainController
    {
        private readonly IMapper _mapper;   
        public HarvestController(IMapper mapper, INotifier notifier) : base(notifier)
        {
            
        }
    }
}