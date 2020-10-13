using api.Models;
using api.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ModelProfiles
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferViewModel>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
