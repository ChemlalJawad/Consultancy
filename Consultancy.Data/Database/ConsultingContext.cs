using Consultancy.Core.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Consultancy.Data.Database
{
    public class ConsultingContext : DbContext
    {
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<ConsultantMission> ConsultantMissions { get; set; }
        public ConsultingContext(DbContextOptions<ConsultingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultantMission>()
                .HasOne(cm => cm.Consultant)
                .WithMany(cm => cm.ConsultantMissions)
                .HasForeignKey(cm => cm.ConsultantId);

            modelBuilder.Entity<ConsultantMission>()
                .HasOne(cm => cm.Mission)
                .WithMany(cm => cm.ConsultantMissions)
                .HasForeignKey(cm => cm.MissionId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.Seed();
        }
    }
}
