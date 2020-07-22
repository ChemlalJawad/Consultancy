using System.Collections.Generic;

namespace Consultancy.Service.Consultant
{
    public interface IConsultantService
    {
       Core.Domains.Consultant GetHistoryMissions(int id);
    }
}
