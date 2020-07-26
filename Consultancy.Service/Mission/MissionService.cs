using Consultancy.Core.Consts;
using Consultancy.Core.Domains;
using Consultancy.Core.Enums;
using Consultancy.Core.Exceptions;
using Consultancy.Data.Database;
using Consultancy.Service.Mission.Request;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Consultancy.Service.Mission
{
    public class MissionService : IMissionService
    {
        private readonly ConsultingContext _consultingContext;

        public MissionService(ConsultingContext consultingContext)
        {
            _consultingContext = consultingContext;
        }

        public ConsultantMission AddConsultant(AddConsultantRequest consultant)
        {
            if (consultant.JobName == null) throw new NotValidException(ErrorVariable.JobnameNotExist);
            if (consultant.Rate == default) throw new NotValidException(ErrorVariable.RateIsNotCompleted);

            var mission = _consultingContext.Missions.FirstOrDefault(e => e.Id == consultant.MissionId);
            if (mission == null) throw new NotValidException(ErrorVariable.MissioNotExist);

            var consult = _consultingContext.Consultants.FirstOrDefault(e => e.Id == consultant.ConsultantId);
            if (consult == null) throw new NotValidException(ErrorVariable.ConsultantNotExist);

            if (mission.ExperienceRequired > consult.Experience) throw new NotValidException(ErrorVariable.ExperienceMinimumRequired);
            var commissions = new Dictionary<Experience, double> 
            {
                [Experience.Junior] = 1.15,
                [Experience.Medior] = 1.10,
                [Experience.Senior] = 1.05
            };
            if (mission.MaximumRate < (consultant.Rate * commissions.GetValueOrDefault(consult.Experience))) throw new NotValidException(ErrorVariable.RateMaximumRequired);

            var lastMissionConsult = _consultingContext.ConsultantMissions
                .Where(e => e.ConsultantId == consultant.ConsultantId)
                .SingleOrDefault(e => e.IsActive);

            if (lastMissionConsult != null) { lastMissionConsult.IsActive = false; }

            var newConsultantMission = new ConsultantMission
            {
                ConsultantId = consultant.ConsultantId,
                MissionId = consultant.MissionId,
                IsActive = true,
                JobName = consultant.JobName,
                Rate = consultant.Rate
            };

            _consultingContext.ConsultantMissions.Add(newConsultantMission);
            _consultingContext.SaveChanges();

            return newConsultantMission;
        }

        public IEnumerable<Core.Domains.Mission> GetMissions()
        {
            var missions = _consultingContext.Missions
                .Include(m => m.ConsultantMissions)
                .ThenInclude(cm => cm.Consultant)
                .ToList();

            foreach (var mission in missions)
            {
                mission.ConsultantMissions = mission.ConsultantMissions.Where(e => e.IsActive).ToList();
            }

            return missions;
        }
    }
}
