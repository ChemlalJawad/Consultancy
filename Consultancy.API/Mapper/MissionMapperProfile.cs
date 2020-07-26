using AutoMapper;
using Consultancy.API.ViewModels.Mission;
using Consultancy.Core.Domains;
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
            CreateMap<Core.Domains.Mission, GetMissionsProfile.MissionProfile>()
                .ForMember(
                  dest => dest.Consultants,
                  opt => opt.MapFrom(src => src.ConsultantMissions));

            CreateMap<ConsultantMission, GetMissionsProfile.MissionProfile.ConsultantProfile>()
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
