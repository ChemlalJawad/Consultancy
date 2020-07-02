using Consultancy.Core.Const;
using Consultancy.Core.Domains;
using Consultancy.Core.Enum;
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

        public ConsultantMission AddConsultant(AddConsultant consultant)
        {
            if (consultant.JobName == null) throw new ValidException(ErrorVariable.JOBNAME_NOT_EXIST);
            if (consultant.Rate == default) throw new ValidException(ErrorVariable.RATE_NOT_EXIST);

            var mission = _consultingContext.Missions.FirstOrDefault(e => e.Id == consultant.MissionId);
            if (mission == null) throw new ValidException(ErrorVariable.MISSION_NOT_EXIST);

            var consult = _consultingContext.Consultants.FirstOrDefault(e => e.Id == consultant.ConsultantId);
            if (consult == null) throw new ValidException(ErrorVariable.CONSULTANT_NOT_EXIST);

            if(mission.ExperienceRequired > consult.Experience) throw new ValidException(ErrorVariable.EXPERIENCE_REQUIRED);
            if(mission.MaximumRate > (consultant.Rate * GetCommission(consult.Experience))) throw new ValidException(ErrorVariable.RATE_REQUIRED);

            var lastMissionConsult = _consultingContext.ConsultantMissions
                .Where(e => e.ConsultantId == consultant.ConsultantId)
                .SingleOrDefault(e => e.isActive);
           
            if(lastMissionConsult == null) throw new ValidException(ErrorVariable.MISSION_NOT_EXIST);
            lastMissionConsult.isActive = false;

            var newConsultantMission = new ConsultantMission
            {
                ConsultantId = consultant.ConsultantId,
                MissionId = consultant.MissionId,
                isActive = true,
                JobName = consultant.JobName,
                Rate = consultant.Rate
            };

            _consultingContext.ConsultantMissions.Update(lastMissionConsult);
            _consultingContext.ConsultantMissions.Add(newConsultantMission);
            _consultingContext.SaveChanges();

            return newConsultantMission;
        }

        public List<Core.Domains.Mission> GetMissions()
        {
            var missions = _consultingContext.Missions
                .Include(m => m.ConsultantMissions)
                .ThenInclude(cm => cm.Consultant)
                .ToList();
                
            return missions;
        }
        public double GetCommission(Experience x)
        {
            switch (x)
            {
                case Experience.Junior: return 1.15;
                case Experience.Medior: return 1.10;
                case Experience.Senior: return 1.05;
            }
            return 0;
        }
    }
}
