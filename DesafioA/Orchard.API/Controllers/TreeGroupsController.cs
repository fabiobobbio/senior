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
    public class TreeGroupsController : MainController
    {
        private readonly ITreeGroupRepository _treeGroupRepository;
        private readonly ITreeGroupService _treeGroupService;
        private readonly IMapper _mapper;
        public TreeGroupsController(IMapper mapper, 
                                    INotifier notifier,
                                    ITreeGroupRepository treeGroupRepository,
                                    ITreeGroupService treeGroupService) : base(notifier)
        {
            _mapper = mapper;
            _treeGroupService = treeGroupService;
            _treeGroupRepository = treeGroupRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TreeGroupsViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TreeGroupsViewModel>>(await _treeGroupRepository.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TreeGroupsViewModel>> FindById(int id)
        {
            var treeGroupsViewModel = await GetTreeGroup(id);

            if (treeGroupsViewModel == null) return NotFound();

            return treeGroupsViewModel;
        
        }

        [HttpPost]
        public async Task<ActionResult<TreeGroupsViewModel>> Add(TreeGroupsViewModel treeGroupsViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _treeGroupService.Add(_mapper.Map<TreeGroup>(treeGroupsViewModel));

            return CustomResponse(treeGroupsViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TreeGroupsViewModel>> Update(int id, TreeGroupsViewModel TreeGroupsViewModel)
        {
            if (id != TreeGroupsViewModel.Id)
            {
                NotifyErro("The id is not the same as what was passed in the query");
                return CustomResponse(TreeGroupsViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _treeGroupService.Update(_mapper.Map<TreeGroup>(TreeGroupsViewModel));

            return CustomResponse(TreeGroupsViewModel);
        }

        // DELETE api/<ServicoTransporteController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TreeGroupsViewModel>> Delete(int id)
        {
            await _treeGroupService.Delete(id);

            return CustomResponse();
        }

        private async Task<TreeGroupsViewModel> GetTreeGroup(int id)
        {
            return _mapper.Map<TreeGroupsViewModel>(await _treeGroupRepository.FindById(id));
        }
    }
}