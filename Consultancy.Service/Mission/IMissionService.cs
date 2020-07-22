using Consultancy.Core.Domains;
using Consultancy.Service.Mission.Request;
using System.Collections.Generic;

namespace Consultancy.Service.Mission
{
    public interface IMissionService
    {
        IEnumerable<Core.Domains.Mission> GetMissions();
        ConsultantMission AddConsultant(AddConsultantRequest consultant);
    }
}
