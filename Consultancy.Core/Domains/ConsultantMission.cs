using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Core.Domains
{
    public class ConsultantMission
    {
        public int Id { get; set; }
        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
        public double Rate { get; set; }
        public string JobName { get; set; }
        public bool IsActive { get; set; }
        public double Commission { get; set; }
    }
}
