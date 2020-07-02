using Consultancy.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Core.Domains
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Experience Experience { get; set; }
        public ICollection<ConsultantMission> ConsultantMissions { get; set; }
    }
}
