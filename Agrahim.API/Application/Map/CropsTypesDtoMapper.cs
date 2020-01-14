using Agrahim.Common.DTOs;
using Agrahim.Infrastructure.Entities;
using AutoMapper;

namespace Agrahim.API.Application.Map
{
    public class CropsTypesDtoMapper : Profile
    {
        public CropsTypesDtoMapper()
        {
            CreateMap<CropsTypeEntity, CropsTypeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CoefficientK, opt => opt.MapFrom(src => src.CoefficientK))
                .ForMember(dest => dest.CoefficientN, opt => opt.MapFrom(src => src.CoefficientN))
                .ForMember(dest => dest.CoefficientP, opt => opt.MapFrom(src => src.CoefficientP))
                .ForMember(dest => dest.IsRemoved, opt => opt.MapFrom(src => src.IsRemoved));
        }
    }
}