﻿using Consultancy.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultancy.API.ViewModels.Consultant
{
    public class HistoryConsultantProfile
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Experience Experience { get; set; }
        public List<MissionProfile> Mission { get; set; }
    }
}