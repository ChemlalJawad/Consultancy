using AutoMapper;
using Consultancy.API.ViewModels.Consultant;
using Consultancy.Core.Domain;
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
            CreateMap<Core.Domain.Consultant, HistoryConsultantProfile>()
               .ForMember(
                 dest => dest.Mission,
                 opt => opt.MapFrom(src => src.ConsultantMissions));

            CreateMap<ConsultantMission, MissionProfile>()
               .ForMember(
                 dest => dest.Name,
                 opt => opt.MapFrom(src => src.Mission.Name));


        }
    
    }
}
