using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rodolfo.Schmidt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodolfo.Schmidt.Data.Configuration
{
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> modelBuilder)
        {
            modelBuilder.ToTable("PERSON");

            modelBuilder
                .Property(p => p.Id)
                .HasColumnName("ID");

            modelBuilder
                .Property(p => p.Name)
                .HasColumnName("NAME")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder
                .Property(p => p.Age)
                .HasColumnName("AGE")
                .IsRequired();

        }
    }
    
}
