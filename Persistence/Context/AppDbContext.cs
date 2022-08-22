using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.CodeFirst;
using Persistence.DbContexTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Context
{
    public class AppDbContext : DbContext, IDbContext
    {  
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new TestMapping());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .Where(e => !e.IsOwned())
            .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

        }
    }
}