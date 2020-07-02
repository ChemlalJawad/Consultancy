using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.ViewModels.Mission
{
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
                total += consultant.Rate * consultant.GetCommission();
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
    }
}
