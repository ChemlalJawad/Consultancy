using Consultancy.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.ViewModels.Mission
{
    public class ConsultantProfile
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Experience Experience { get; set; }
        public double Rate { get; set; }
        public string JobName { get; set; }
    }
}
