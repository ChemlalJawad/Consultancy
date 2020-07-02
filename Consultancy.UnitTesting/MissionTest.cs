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
using Consultancy.Core.Domains;

namespace Consultancy.UnitTesting
{
    public class MissionTest : ServiceContext
    {
        public MissionTest() : base(
            new DbContextOptionsBuilder<ConsultingContext>()
                .UseInMemoryDatabase("Test")
                .Options)
        { 
        }

        [Fact]
        public void AddConsultant_JobNameNotValidExcpetion()
        {
            using (var context = new ConsultingContext(ContextOptions))
            {
                var service = new MissionService(context);
               // context.ConsultantMissions.Add(new ConsultantMission { Id = 3, ConsultantId = 1, MissionId = 1, JobName = "Jaja", Rate = 400.00, isActive = true });
                //context.SaveChanges();
                var addConsultant = new AddConsultant
                {
                    ConsultantId = 1,
                    MissionId = 1,
                    Rate = 400.00
                };
                Action action = () => service.AddConsultant(addConsultant);
                action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.JOBNAME_NOT_EXIST);
            }
        }
        
        [Fact]
        public void AddConsultant_RateNotValidExcpetion()
        {
            using (var context = new ConsultingContext(ContextOptions))
            {
                var service = new MissionService(context);
                //context.ConsultantMissions.Add(new ConsultantMission { Id = 2, ConsultantId = 3, MissionId = 3, JobName = "Jaja", Rate = 400.00, isActive = true });
                //context.SaveChanges();
                var addConsultant = new AddConsultant
                {
                    ConsultantId = 3,
                    MissionId = 3,
                    JobName = "Java Dev"
                };
                Action action = () => service.AddConsultant(addConsultant);
                action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.RATE_NOT_EXIST);
            }
        }  
        
        [Fact]
        public void AddConsultant_MissionNotValidExcpetion()
        {
            using (var context = new ConsultingContext(ContextOptions))
            {
                var service = new MissionService(context);
                //context.ConsultantMissions.Add(new ConsultantMission { Id = 1, ConsultantId = 1, MissionId = 1, JobName = "Jaja", Rate = 400.00, isActive = true });
                //context.SaveChanges();
                
                var addConsultant = new AddConsultant
                {
                    ConsultantId = 1,
                    MissionId = 20,
                    JobName = "Java Dev",
                    Rate = 400.00
                };

                Action action = () => service.AddConsultant(addConsultant);
                action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.MISSION_NOT_EXIST);
            }           
        }        

        [Fact]
        public void AddConsultant_ConsultantNotValidExcpetion()
        {
            using (var context = new ConsultingContext(ContextOptions))
            {
                var service = new MissionService(context);               
                var addConsultant = new AddConsultant
                {
                    ConsultantId = 40,
                    MissionId = 1,
                    JobName = "Java Dev",
                    Rate = 400.00
                };

                Action action = () => service.AddConsultant(addConsultant);
                action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.CONSULTANT_NOT_EXIST);
            }           
        }

        [Fact]
        public void AddConsultant_ExperienceNotValidExcpetion()
        {
            using (var context = new ConsultingContext(ContextOptions))
            {
                var service = new MissionService(context);               
                var addConsultant = new AddConsultant
                {
                    ConsultantId = 1,
                    MissionId = 1,
                    JobName = "Java Dev",
                    Rate = 400.00
                };

                Action action = () => service.AddConsultant(addConsultant);
                action.Should().ThrowExactly<ValidException>().WithMessage(ErrorVariable.EXPERIENCE_REQUIRED);
            }           
        }

        [Fact]
        public void AddConsultant_IsValid()
        {
            using (var context = new ConsultingContext(ContextOptions))
            {
                var service = new MissionService(context);               
                var addConsultant = new AddConsultant
                {
                    ConsultantId = 3,
                    MissionId = 3,
                    JobName = "Dev Lead",
                    Rate = 500.00
                };

                var result = service.AddConsultant(addConsultant);
                result.ConsultantId.Should().Be(3);
                result.MissionId.Should().Be(3);
                result.isActive.Should().Be(true);
                result.Rate.Should().Be(500.00);
            }           
        }
    }
}
