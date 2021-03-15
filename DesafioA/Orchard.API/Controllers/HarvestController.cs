using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Orchard.API.ViewModels;
using Orchard.Domain;
using Orchard.Domain.Interfaces;

namespace Orchard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestController : MainController
    {
        private readonly IHarvestRepository _harvestRepository;
        private readonly IHarvestService _harvestService;
        private readonly IMapper _mapper;   
        public HarvestController(IMapper mapper, 
                                 INotifier notifier,
                                 IHarvestService harvestService,
                                 IHarvestRepository harvestRepository) : base(notifier)
        {
            _mapper = mapper;
            _harvestService = harvestService;
            _harvestRepository = harvestRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<HarvestViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<HarvestViewModel>>(await _harvestRepository.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HarvestViewModel>> FindById(int id)
        {
            var harvestViewModel = await GetHarvest(id);

            if (harvestViewModel == null) return NotFound();

            return harvestViewModel;
        
        }

        [HttpPost]
        public async Task<ActionResult<HarvestViewModel>> Add(HarvestViewModel harvestViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _harvestService.Add(_mapper.Map<Harvest>(harvestViewModel));

            return CustomResponse(harvestViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HarvestViewModel>> Update(int id, HarvestViewModel harvestViewModel)
        {
            if (id != harvestViewModel.Id)
            {
                NotifyErro("The id is not the same as what was passed in the query");
                return CustomResponse(harvestViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _harvestService.Update(_mapper.Map<Harvest>(harvestViewModel));

            return CustomResponse(harvestViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HarvestViewModel>> Delete(int id)
        {
            await _harvestService.Delete(id);

            return CustomResponse();
        }

        private async Task<HarvestViewModel> GetHarvest(int id)
        {
            return _mapper.Map<HarvestViewModel>(await _harvestRepository.FindById(id));
        }
    }
}