using Consultancy.Core.Enums;
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
            var commissions = new Dictionary<Experience, double>
            {
                [Experience.Junior] = 1.15,
                [Experience.Medior] = 1.10,
                [Experience.Senior] = 1.05,
            };      
            var total = 0.00;
            foreach (var consultant in Consultants)
            {
                total += consultant.Rate * commissions.GetValueOrDefault(consultant.Experience);
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
