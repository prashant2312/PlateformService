using AutoMapper;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Profiles
{
    public class PlateformsProfile:Profile
    {
        public PlateformsProfile()
        {
            // Source -> target
            CreateMap<Plateform, PlateformReadDto>();
            CreateMap<PlateformCreateDto, Plateform>();

        }
    }
}
