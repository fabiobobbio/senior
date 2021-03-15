using AutoMapper;
using Orchard.API.ViewModels;
using Orchard.Domain;

namespace Orchard.API.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Harvest, HarvestViewModel>().ReverseMap();
            CreateMap<Tree, TreeViewModel>().ReverseMap();
            CreateMap<TreeGroup, TreeGroupsViewModel>().ReverseMap();
            CreateMap<Specie, SpeciesViewModel>().ReverseMap();
        }
    }
}