﻿using System.Collections.Generic;

namespace Consultancy.Service.Consultant
{
    public interface IConsultantService
    {
       Core.Domains.Consultant HistoryMissions(int id);
       List<Core.Domains.Consultant> GetAll();
    }
}
