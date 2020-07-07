using AutoMapper;
using Consultancy.API.ViewModels.Mission;
using Consultancy.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.Mapper
{
    public class MissionMapperProfile : Profile
    {
        public MissionMapperProfile()
        {
            CreateMap<Core.Domain.Mission, MissionProfile>()
                .ForMember(
                  dest => dest.Consultants,
                  opt => opt.MapFrom(src => src.ConsultantMissions));

            CreateMap<ConsultantMission, ConsultantProfile>()
                .ForMember(
                    dest => dest.Lastname,
                    opt => opt.MapFrom(src => src.Consultant.Lastname))
                .ForMember(
                    dest => dest.Firstname,
                    opt => opt.MapFrom(src => src.Consultant.Firstname))
                .ForMember(
                    dest => dest.Experience,
                    opt => opt.MapFrom(src => src.Consultant.Experience));
        }
    
    }
}
