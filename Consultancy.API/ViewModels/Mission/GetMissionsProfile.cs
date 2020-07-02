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
    }
}
