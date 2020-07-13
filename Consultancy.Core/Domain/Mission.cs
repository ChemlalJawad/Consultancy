using Consultancy.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Core.Domain
{
    public class Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MaximumRate { get; set; }
        public Experience ExperienceRequired { get; set; }
        public ICollection<ConsultantMission> ConsultantMissions { get; set; }
    }
}
