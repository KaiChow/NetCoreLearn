using AutoMapper;
using MyTourist.Dtos;
using MyTourist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTourist.Profiles
{
    public class TouristRouteProfile : Profile
    {

        //  使用数据投影  model-> dto
        public TouristRouteProfile()
        {
            CreateMap<TouristRoute, TouristTouteDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPresent ?? 1)));


            CreateMap<TouristRouteForCreationDto, TouristRoute>()
                    .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                    );
        }
    }
}
