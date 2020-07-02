using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Core.Const
{
    public class ErrorVariable
    {
        public static string JOBNAME_NOT_EXIST => "Job name does not exist";
        public static string RATE_NOT_EXIST => "Rate does not exist";
        public static string MISSION_NOT_EXIST => "Mission does not exist";
        public static string CONSULTANT_NOT_EXIST => "Consultant does not exist";
        public static string EXPERIENCE_REQUIRED => "The experience of the consultant does not correspond to the experience required for the mission";
        public static string RATE_REQUIRED => "The rate charged (with commission from the company) must not be greater than the limit imposed by the assignment.";
    }
}
