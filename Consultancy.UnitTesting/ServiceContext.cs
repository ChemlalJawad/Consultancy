using Consultancy.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultancy.UnitTesting
{
    public class ServiceContext
    {
        protected DbContextOptions<ConsultingContext> ContextOptions { get; }

        protected ServiceContext(DbContextOptions<ConsultingContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        private void Seed()
        {

            using (var context = new ConsultingContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                //context.SaveChanges();
            }
        }
    }
}
