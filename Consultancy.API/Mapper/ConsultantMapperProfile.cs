using AutoMapper;
using Consultancy.API.ViewModels.Consultant;
using Consultancy.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.Mapper
{
    public class ConsultantMapperProfile : Profile
    {
        public ConsultantMapperProfile()
        {
            CreateMap<Core.Domains.Consultant, HistoryConsultantProfile>()
               .ForMember(
                 dest => dest.Firstname,
                 opt => opt.MapFrom(src => src.Firstname))
               .ForMember(
                 dest => dest.Lastname,
                 opt => opt.MapFrom(src => src.Lastname))
               .ForMember(
                 dest => dest.Experience,
                 opt => opt.MapFrom(src => src.Experience))
               .ForMember(
                 dest => dest.Mission,
                 opt => opt.MapFrom(src => src.ConsultantMissions));

            CreateMap<ConsultantMission, MissionProfile>()
               .ForMember(
                 dest => dest.JobName,
                 opt => opt.MapFrom(src => src.JobName))
               .ForMember(
                 dest => dest.Name,
                 opt => opt.MapFrom(src => src.Mission.Name))
               .ForMember(
                 dest => dest.Rate,
                 opt => opt.MapFrom(src => src.Rate))
               .ForMember(
                 dest => dest.isActive,
                 opt => opt.MapFrom(src => src.isActive));

        }
    
    }
}
