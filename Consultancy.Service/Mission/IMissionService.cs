using Consultancy.Core.Domain;
using Consultancy.Service.Mission.Request;
using System.Collections.Generic;

namespace Consultancy.Service.Mission
{
    public interface IMissionService
    {
        IEnumerable<Core.Domain.Mission> GetMissions();
        ConsultantMission AddConsultant(AddConsultantRequest consultant);
    }
}
