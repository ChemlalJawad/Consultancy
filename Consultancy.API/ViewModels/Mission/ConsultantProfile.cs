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
        public double GetCommission()
        {
            switch (Experience)
            {
                case Experience.Junior: return 1.15;
                case Experience.Medior: return 1.10;
                case Experience.Senior: return 1.05;
            }
            return 0;
        }
    }
}
