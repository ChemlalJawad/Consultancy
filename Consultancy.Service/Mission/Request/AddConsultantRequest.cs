using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Service.Mission.Request
{
    public class AddConsultantRequest
    {
        public int ConsultantId { get; set; }
        public int MissionId { get; set; }
        public double Rate { get; set; }
        public string JobName { get; set; }
        public double Commission { get; set; }
    }
}
