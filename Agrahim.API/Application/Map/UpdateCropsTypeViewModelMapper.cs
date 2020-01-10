using Agrahim.Common.ViewModels;
using Agrahim.Infrastructure.Entities;
using AutoMapper;

namespace Agrahim.API.Application.Map
{
    public class UpdateCropsTypeViewModelMapper : Profile
    {
        public UpdateCropsTypeViewModelMapper()
        {
            CreateMap<CropsTypeEntity, UpdateCropsTypeViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsRemoved, opt => opt.MapFrom(src => src.IsRemoved));
        }
    }
}