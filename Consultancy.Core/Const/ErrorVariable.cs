using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Core.Const
{
    public class ErrorVariable
    {
        public static string JobnameNotExist => "Job name does not exist";
        public static string RateIsNotCompleted => "Rate is not completed";
        public static string MissioNotExist => "Mission does not exist";
        public static string ConsultantNotExist => "Consultant does not exist";
        public static string ExperienceMinimumRequired => "The experience of the consultant does not correspond to the experience required for the mission";
        public static string RateMaximumRequired => "The rate charged (with commission from the company) must not be greater than the limit imposed by the assignment.";
    }
}
