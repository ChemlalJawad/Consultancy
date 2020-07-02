using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.ViewModels.Consultant
{
    public class MissionProfile
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public string JobName { get; set; }
        public bool isActive { get; set; }
    }
}
