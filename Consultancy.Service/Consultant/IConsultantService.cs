using System.Collections.Generic;

namespace Consultancy.Service.Consultant
{
    public interface IConsultantService
    {
       Core.Domain.Consultant GetHistoryMissions(int id);
    }
}
