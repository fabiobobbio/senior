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
    public class SpeciesController : MainController
    {
        private readonly ISpecieRepository _speciesRepository;
        private readonly ISpecieService _specieService;
        private readonly IMapper _mapper;
        public SpeciesController(IMapper mapper, 
                                 INotifier notifier,
                                 ISpecieService specieService,
                                 ISpecieRepository specieRepository) : base(notifier)
        {
            _mapper = mapper;
            _speciesRepository = specieRepository;
            _specieService = specieService;
        }

        [HttpGet]
        public async Task<IEnumerable<SpeciesViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<SpeciesViewModel>>(await _speciesRepository.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SpeciesViewModel>> FindById(int id)
        {
            var speciesViewModel = await GetSpecie(id);

            if (speciesViewModel == null) return NotFound();

            return speciesViewModel;
        
        }

        [HttpPost]
        public async Task<ActionResult<SpeciesViewModel>> Add(SpeciesViewModel speciesViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _specieService.Add(_mapper.Map<Specie>(speciesViewModel));

            return CustomResponse(speciesViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SpeciesViewModel>> Update(int id, SpeciesViewModel speciesViewModel)
        {
            if (id != speciesViewModel.Id)
            {
                NotifyErro("The id is not the same as what was passed in the query");
                return CustomResponse(speciesViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _specieService.Update(_mapper.Map<Specie>(speciesViewModel));

            return CustomResponse(speciesViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SpeciesViewModel>> Delete(int id)
        {
            await _specieService.Delete(id);

            return CustomResponse();
        }

        private async Task<SpeciesViewModel> GetSpecie(int id)
        {
            return _mapper.Map<SpeciesViewModel>(await _speciesRepository.FindById(id));
        }
    }
}