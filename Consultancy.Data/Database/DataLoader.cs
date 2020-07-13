using Consultancy.Core.Domain;
using Consultancy.Core.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.Data.Database
{
    public static class DataLoader 
    {
       
            public static void Seed(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Consultant>().HasData(new Consultant()
                {
                    Id = 1,
                    Firstname = "Jawad",
                    Lastname = "Chemlal",
                    Experience = Experience.Junior
                },
                new
                {
                    Id = 2,
                    Firstname = "Xavier",
                    Lastname = "Piekara",
                    Experience = Experience.Medior
                },
                new
                {
                    Id = 3,
                    Firstname = "Loic",
                    Lastname = "Ramelot",
                    Experience = Experience.Senior
                });

                modelBuilder.Entity<Mission>().HasData(new Mission()
                {
                    Id = 1,
                    Name = "Google",
                    MaximumRate = 500.00,
                    ExperienceRequired = Experience.Medior
                },
                new
                {
                    Id = 2,
                    Name = "Amazon",
                    MaximumRate = 700.00,
                    ExperienceRequired = Experience.Senior
                },
                new
                {
                    Id = 3,
                    Name = "NRB",
                    MaximumRate = 400.00,
                    ExperienceRequired = Experience.Junior
                });

                modelBuilder.Entity<ConsultantMission>().HasData(new ConsultantMission()
                {
                    Id =1,
                    ConsultantId = 1,
                    MissionId = 3,
                    Rate = 400.00,
                    IsActive = true,
                    JobName = "Dev"
                },
                new
                {
                    Id = 2,
                    ConsultantId = 2,
                    MissionId = 1,
                    Rate = 400.00,
                    IsActive = true,
                    JobName = "Consultant"
                },
                new
                {
                    Id = 3,
                    ConsultantId = 2,
                    Rate = 400.00,
                    MissionId = 3,
                    IsActive = false,
                    JobName = "Dev"

                },
                new
                {
                    Id = 4,
                    ConsultantId = 3,
                    Rate = 400.00,
                    MissionId = 2,
                    IsActive = false,
                    JobName = "Dev"
                },
                new
                {
                    Id = 5,
                    ConsultantId = 3,
                    MissionId = 3,
                    Rate = 500.00,
                    IsActive = true,
                    JobName = "Dev"
                },
                new
                {
                    Id = 6,
                    ConsultantId = 3,
                    MissionId = 1,
                    Rate = 400.00,
                    IsActive = false,
                    JobName = "Dev"
                }
                );

            }
    }
}
