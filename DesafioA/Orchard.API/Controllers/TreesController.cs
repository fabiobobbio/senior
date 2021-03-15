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
    public class TreesController : MainController
    {
        private readonly ITreeRepository _treeRepository;
        private readonly ITreeService _treeService;
        private readonly IMapper _mapper;

        public TreesController(IMapper mapper, 
                               INotifier notifier,
                               ITreeRepository treeRepository,
                               ITreeService treeService) : base(notifier)
        {
            _mapper = mapper;
            _treeRepository = treeRepository;
            _treeService = treeService;
        }

        [HttpGet]
        public async Task<IEnumerable<TreeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TreeViewModel>>(await _treeRepository.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TreeViewModel>> FindById(int id)
        {
            var treeViewModel = await GetTree(id);

            if (treeViewModel == null) return NotFound();

            return treeViewModel;
        
        }

        [HttpPost]
        public async Task<ActionResult<TreeViewModel>> Add(TreeViewModel treeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _treeService.Add(_mapper.Map<Tree>(treeViewModel));

            return CustomResponse(treeViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TreeViewModel>> Update(int id, TreeViewModel TreeViewModel)
        {
            if (id != TreeViewModel.Id)
            {
                NotifyErro("The id is not the same as what was passed in the query");
                return CustomResponse(TreeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _treeService.Update(_mapper.Map<Tree>(TreeViewModel));

            return CustomResponse(TreeViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TreeViewModel>> Delete(int id)
        {
            await _treeService.Delete(id);

            return CustomResponse();
        }

        private async Task<TreeViewModel> GetTree(int id)
        {
            return _mapper.Map<TreeViewModel>(await _treeRepository.FindById(id));
        }
    }
}