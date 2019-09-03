using Microsoft.EntityFrameworkCore;
using Rodolfo.Schmidt.Data.Configuration;
using Rodolfo.Schmidt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodolfo.Schmidt.Data.Context
{
    public class RodolfoSchmidtDbContext : DbContext
    {
        public RodolfoSchmidtDbContext()
        {
        }
        public RodolfoSchmidtDbContext(DbContextOptions<RodolfoSchmidtDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
