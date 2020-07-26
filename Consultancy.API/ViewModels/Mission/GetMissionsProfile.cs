using Consultancy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.ViewModels.Mission
{
    public class GetMissionsProfile
    {
        public double TotalIncome => GetTotalIncome();
        public double TotalProfit => GetTotalProfit();
        public List<MissionProfile> Missions { get; set; }
        public double GetTotalIncome()
        {
            var total = 0.00;
            foreach (var mission in Missions)
            {
                total += mission.DailyIncome;
            }
            return Math.Round(total, 2);
        }
        public double GetTotalProfit()
        {
            var total = 0.00;
            foreach (var mission in Missions)
            {
                total += mission.DailyProfit;
            }
            return Math.Round(total, 2);
        }
        public class MissionProfile
        {
            public int ConsultantNumber => Consultants.Count();
            public double DailyIncome => GetDailyIncome();
            public double DailyProfit => GetDailyProfit();
            public List<ConsultantProfile> Consultants { get; set; }

            public double GetDailyIncome()
            {             
                var total = 0.00;
                foreach (var consultant in Consultants)
                {
                    total += consultant.Rate *consultant.Commission;
                }
                return Math.Round(total, 2);

            }
            public double GetDailyProfit()
            {
                var total = 0.00;

                foreach (var consultant in Consultants)
                {
                    total += consultant.Rate;
                }

                return Math.Round((GetDailyIncome() - total), 2);
            }

            public class ConsultantProfile
            {
                public string Firstname { get; set; }
                public string Lastname { get; set; }
                public Experience Experience { get; set; }
                public double Rate { get; set; }
                public string JobName { get; set; }
                public double Commission { get; set; }
            }
        }
    }
}
