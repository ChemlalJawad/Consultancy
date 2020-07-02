using FluentAssertions;
using Consultancy.Data.Database;
using Consultancy.Service.Mission;
using Consultancy.Service.Mission.Request;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Consultancy.Core.Exceptions;
using Consultancy.Core.Const;
using NUnit.Framework;

namespace Consultancy.UnitTesting
{
    public class MissionTest : TestingContext<MissionService>
    {  
        public MissionTest()
        {
            base.Setup();
        }

        [Fact]
        public void AddConsultant_JobNameNotValidExcpetion()
        {
            var addConsultant = new AddConsultant
            {
                ConsultantId = 1,
                MissionId = 1,
                Rate = 400.00
            };
            GetMockFor<IMissionService>().Setup(x => x.AddConsultant(addConsultant)).Returns(new Core.Domains.ConsultantMission { ConsultantId = 1 , MissionId = 1, Rate = 400} );
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.JOBNAME_NOT_EXIST);
        }

        [Fact]
        public void AddConsultant_RateNotValidExcpetion()
        {
            var addConsultant = new AddConsultant
            {
                ConsultantId = 1,
                MissionId = 1,
                JobName = "Java Dev"
            };
            GetMockFor<IMissionService>().Setup(x => x.AddConsultant(addConsultant)).Returns(new Core.Domains.ConsultantMission { ConsultantId = 1 , MissionId = 1, JobName = "Java Dev" } );
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.RATE_NOT_EXIST);
        }  
        
        [Fact]
        public void AddConsultant_MissionNotValidExcpetion()
        {
            var addConsultant = new AddConsultant
            {
                ConsultantId = 1,
                MissionId = 20,
                JobName = "Java Dev",
                Rate = 400.00
            };
            GetMockFor<IMissionService>().Setup(x => x.AddConsultant(addConsultant)).Returns(new Core.Domains.ConsultantMission { ConsultantId = 1 , MissionId = 1, Rate = 400, JobName = "Java Dev", } );
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.MISSION_NOT_EXIST);
        }
        
       
    }
}
