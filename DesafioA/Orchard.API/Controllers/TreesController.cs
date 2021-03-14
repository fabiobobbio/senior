using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Orchard.Repository.Interfaces;

namespace Orchard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreesController : MainController
    {
        private readonly IMapper _mapper;

        public TreesController(IMapper mapper, INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
        }
    }
}