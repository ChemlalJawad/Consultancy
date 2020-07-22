using FluentAssertions;
using Consultancy.Data.Database;
using Consultancy.Service.Mission;
using Consultancy.Service.Mission.Request;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Consultancy.Core.Exceptions;
using Consultancy.Core.Consts;
using NUnit.Framework;
using Consultancy.Core.Domains;
using AutoFixture;
using Consultancy.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Consultancy.UnitTesting
{
    public class MissionTest : TestingContext<MissionService>
    {
        public MissionTest()
        {
            base.Setup();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        private ConsultingContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<ConsultingContext>()
              .UseInMemoryDatabase(databaseName: "ConsultancyTest")
              .Options;

            var context = new ConsultingContext(options);
            context.Database.EnsureDeleted();
            SeedDatabase(context);
            context.SaveChanges();
            return context;
        }

        private void SeedDatabase(ConsultingContext context)
        {
            context.Consultants.AddRange(new List<Consultant> 
            {
                new Consultant
                {
                    Id = 21,
                    Firstname = "Jawad",
                    Lastname = "Chemlal",
                    Experience = Experience.Medior
                },
                new Consultant
                {
                    Id = 22,
                    Firstname = "Fabrice",
                    Lastname = "Eboué",
                    Experience = Experience.Senior
                }
            });
            context.Missions.AddRange(new List<Mission>
            {    
                new Mission
                {
                    Id = 31,
                    Name = "Genesis",
                    MaximumRate = 600.00,
                    ExperienceRequired = Experience.Senior
                },
                new Mission
                {
                    Id = 32,
                    Name = "Microsoft",
                    MaximumRate = 500.00,
                    ExperienceRequired = Experience.Medior
                },                
                new Mission
                {
                    Id = 33,
                    Name = "Google",
                    MaximumRate = 400.00,
                    ExperienceRequired = Experience.Medior
                }
            });
            context.ConsultantMissions.AddRange(new List<ConsultantMission>
            { 
                new ConsultantMission
                {
                    Id =17,
                    ConsultantId = 21,
                    MissionId = 32,
                    Rate = 400.00,
                    IsActive = true,
                    JobName = "Medior Dev"
                },
                 new ConsultantMission
                {
                    Id =18,
                    ConsultantId = 22,
                    MissionId = 31,
                    Rate = 600.00,
                    IsActive = true,
                    JobName = "Senior Dev"
                }, new ConsultantMission
                {
                    Id =19,
                    ConsultantId = 22,
                    MissionId = 32,
                    Rate = 500.00,
                    IsActive = false,
                    JobName = "Medior Dev"
                }
            });
           
        }
        [Fact]
        public void AddConsultant_JobNameNotValidExcpetion()
        {
            var addConsultant = new AddConsultantRequest();
                
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.JobnameNotExist);
            
        }
      
        [Fact]
        public void AddConsultant_RateNotValidExcpetion()
        {
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 1,
                    MissionId = 1,
                    JobName = "Dev Lead"
                };
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.RateIsNotCompleted);           
        }  
        
        [Fact]
        public void AddConsultant_MissionNotValidExcpetion()
        {
            var context = InitializeContext();
            InjectClassFor(context);
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 21,
                    MissionId = 20,
                    JobName = "Java Dev",
                    Rate = 400.00
                };
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.MissioNotExist);          
        }        
        
        [Fact]
        public void AddConsultant_RateHighNotValidExcpetion()
        {
            var context = InitializeContext();
            InjectClassFor(context);
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 22,
                    MissionId = 33,
                    JobName = "Java Dev",
                    Rate = 300.00
                };
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.RateMaximumRequired);           
        }        

        [Fact]
        public void AddConsultant_ConsultantNotValidExcpetion()
        {
            var context = InitializeContext();
            InjectClassFor(context);
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 40,
                    MissionId = 31,
                    JobName = "Java Dev",
                    Rate = 400.00
                };
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.ConsultantNotExist);           
        }

        [Fact]
        public void AddConsultant_ExperienceNotValidExcpetion()
        {
            var context = InitializeContext();
            InjectClassFor(context);
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 21,
                    MissionId = 31,
                    JobName = "Java Dev",
                    Rate = 400.00
                };
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.ExperienceMinimumRequired);            
        }

        [Fact]
        public void AddConsultant_LastMissionNeedToBeFalse()
        {
            var context = InitializeContext();
            InjectClassFor(context);
            var addConsultant = new AddConsultantRequest
            {
                ConsultantId = 21,
                MissionId = 33,
                JobName = "Dev Lead",
                Rate = 400.00
            };
            
            var result = ClassUnderTest.AddConsultant(addConsultant);
            result.Consultant.ConsultantMissions.Where(x => x.IsActive).Count().Should().Be(1);
        }    
        [Fact]
        public void AddConsultant_IsValid()
        {
            var context = InitializeContext();
            InjectClassFor(context);
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 22,
                    MissionId = 33,
                    JobName = "Dev Lead",
                    Rate = 400.00
                };
    
            var result = ClassUnderTest.AddConsultant(addConsultant);
            result.ConsultantId.Should().Be(22);
            result.MissionId.Should().Be(33);
            result.IsActive.Should().Be(true);
            result.Rate.Should().Be(400.00);     
        }
    }
}
