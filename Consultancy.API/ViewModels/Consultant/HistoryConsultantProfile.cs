using Consultancy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.ViewModels.Consultant
{
    public class HistoryConsultantProfile
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Experience Experience { get; set; }
        public List<MissionProfile> Mission { get; set; }
        public class MissionProfile
        {
            public string Name { get; set; }
            public double Rate { get; set; }
            public string JobName { get; set; }
            public bool IsActive { get; set; }
        }
    }

}
