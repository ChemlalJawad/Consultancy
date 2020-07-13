using Consultancy.Data.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Consultancy.Service.Consultant
{
    public class ConsultantService : IConsultantService
    {
        private readonly ConsultingContext _consultingContext;

        public ConsultantService(ConsultingContext consultingContext)
        {
            _consultingContext = consultingContext;
        }

        public Core.Domain.Consultant GetHistoryMissions(int id)
        {
            return  _consultingContext.Consultants
               .Include(m => m.ConsultantMissions)
               .ThenInclude(m => m.Mission)
               .FirstOrDefault(c => c.Id == id);
        }
    }
}
