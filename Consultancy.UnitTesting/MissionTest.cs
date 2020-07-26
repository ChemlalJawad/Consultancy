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

            context.SaveChanges();
            return context;
        }

        [Fact]
        public void AddConsultant_JobNameNotValidExcpetion()
        {
            // Arrange
            var addConsultant = new AddConsultantRequest();
            
            // Act
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.JobnameNotExist);
            
        }
      
        [Fact]
        public void AddConsultant_RateNotValidExcpetion()
        {
            // Arrange
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 1,
                    MissionId = 1,
                    JobName = "Dev Lead"
                };

            // Act
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.RateIsNotCompleted);           
        }  
        
        [Fact]
        public void AddConsultant_MissionNotValidExcpetion()
        {
            // Arrange
            var context = InitializeContext();
            var consultant = fixture.Build<Consultant>().With(x => x.Id, 1).Create();
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 1,
                    MissionId = 20,
                    JobName = "Java Dev",
                    Rate = 400.00
                };
            context.Consultants.Add(consultant);
            context.SaveChanges();
            InjectClassFor(context);

            // Act
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.MissioNotExist);          
        }        
        
        [Fact]
        public void AddConsultant_RateHighNotValidExcpetion()
        {
            // Arrange
            var context = InitializeContext();
            var consultant = fixture.Build<Consultant>().With(x => x.Id, 1).With(x => x.Experience, Experience.Medior).Create();
            var mission = fixture.Build<Mission>().With(x => x.Id, 1).With(x => x.ExperienceRequired, Experience.Medior).With(x => x.MaximumRate, 400).Create();
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 1,
                    MissionId = 1,
                    JobName = "Java Dev",
                    Rate = 600.00
                };

            context.Consultants.Add(consultant);
            context.Missions.Add(mission);
            context.SaveChanges();
            InjectClassFor(context);
            // Act
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.RateMaximumRequired);           
        }        

        [Fact]
        public void AddConsultant_ConsultantNotValidExcpetion()
        {
            // Arrange
            var context = InitializeContext();
            var mission = fixture.Build<Mission>().With(x => x.Id, 2).Create();
            var addConsultant = new AddConsultantRequest
            {
                ConsultantId = 20,
                MissionId = 2,
                JobName = "Java Dev",
                Rate = 300.00
            };

            context.Missions.Add(mission);
            context.SaveChanges();
            InjectClassFor(context);

            // Act
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.ConsultantNotExist);           
        }

        [Fact]
        public void AddConsultant_ExperienceNotValidExcpetion()
        {
            // Arrange
            var context = InitializeContext();
            var consultant = fixture.Build<Consultant>().With(x => x.Id, 10).With(x => x.Experience, Experience.Medior).Create();
            var mission = fixture.Build<Mission>().With(x => x.Id, 1).With(x => x.ExperienceRequired, Experience.Senior).With(x => x.MaximumRate, 1000).Create();
            var addConsultant = new AddConsultantRequest
            {
                ConsultantId = 10,
                MissionId = 1,
                JobName = "Java Dev",
                Rate = 400.00
            };

            context.Consultants.Add(consultant);
            context.Missions.Add(mission);
            context.SaveChanges();
            InjectClassFor(context);

            // Act
            Action action = () => ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            action.Should().ThrowExactly<NotValidException>().WithMessage(ErrorVariable.ExperienceMinimumRequired);            
        }

        [Fact]
        public void AddConsultant_LastMissionNeedToBeFalse()
        {
            // Arrange
            var context = InitializeContext();
            var consultant = fixture.Build<Consultant>().With(x => x.Id, 21).With(x => x.Experience, Experience.Medior).Create();
            var mission = fixture.Build<Mission>().With(x => x.Id, 11).With(x => x.ExperienceRequired, Experience.Junior).With(x => x.MaximumRate, 1000).Create();
            var addConsultant = new AddConsultantRequest
            {
                ConsultantId = 21,
                MissionId = 11,
                JobName = "Java Dev",
                Rate = 400.00
            };
            var consultantMissions = new List<ConsultantMission> { new ConsultantMission { IsActive = true }, new ConsultantMission { IsActive = false } };
            
            consultant.ConsultantMissions = consultantMissions;
            mission.ConsultantMissions = consultantMissions;
            context.Consultants.Add(consultant);
            context.Missions.Add(mission);
            context.SaveChanges();
            InjectClassFor(context);

            // Act
            var result = ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            result.Consultant.ConsultantMissions.Where(x => x.IsActive).Count().Should().Be(1);
        }    
        [Fact]
        public void AddConsultant_CommissionTest()
        {
            // Arrange
            var context = InitializeContext();
            var consultant = fixture.Build<Consultant>().With(x => x.Id, 100).With(x => x.Experience, Experience.Medior).Create();
            var mission = fixture.Build<Mission>().With(x => x.Id, 29).With(x => x.ExperienceRequired, Experience.Junior).With(x => x.MaximumRate, 1000).Create();
            var addConsultant = new AddConsultantRequest
            {
                ConsultantId = 100,
                MissionId = 29,
                JobName = "C# .Net Dev",
                Rate = 400.00
            };
            var consultantMissions = new List<ConsultantMission> { new ConsultantMission { IsActive = true }, new ConsultantMission { IsActive = false } };
            
            consultant.ConsultantMissions = consultantMissions;
            mission.ConsultantMissions = consultantMissions;
            context.Consultants.Add(consultant);
            context.Missions.Add(mission);
            context.SaveChanges();
            InjectClassFor(context);

            // Act
            var result = ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            result.Consultant.ConsultantMissions.Where(x => x.IsActive).Count().Should().Be(1);
            result.Consultant.ConsultantMissions.Where(x => x.IsActive).FirstOrDefault().Commission.Should().Be(440.00);
        }    
        [Fact]
        public void AddConsultant_IsValid()
        {
            // Arrange
            var context = InitializeContext();
            var consultant = fixture.Build<Consultant>().With(x => x.Id, 40).With(x => x.Experience, Experience.Medior).Create();
            var mission = fixture.Build<Mission>().With(x => x.Id,40).With(x => x.ExperienceRequired, Experience.Junior).With(x => x.MaximumRate, 1000).Create();
            var consultantMissions = new List<ConsultantMission> { new ConsultantMission { IsActive = true }, new ConsultantMission { IsActive = false } };
            var addConsultant = new AddConsultantRequest
                {
                    ConsultantId = 40,
                    MissionId = 40,
                    JobName = "Dev Lead",
                    Rate = 400.00
                };

            consultant.ConsultantMissions = consultantMissions;
            mission.ConsultantMissions = consultantMissions;
            context.Consultants.Add(consultant);
            context.Missions.Add(mission);
            context.SaveChanges();
            InjectClassFor(context);

            // Act
            var result = ClassUnderTest.AddConsultant(addConsultant);

            // Assert
            result.ConsultantId.Should().Be(40);
            result.MissionId.Should().Be(40);
            result.IsActive.Should().Be(true);
            result.Rate.Should().Be(400.00);     
        }
    }
}
