using System;
using Microsoft.EntityFrameworkCore;
using PetAPI.Core.Models;

namespace PetAPI.Infrastructure.Data
{
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public DbSet<Shelter> Shelters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source =../PetAPI.Infrastructure/animals.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shelter>().HasData(
                new Shelter { Id = 1, Name = "Lubbock Animal Shelter & Adoption Center", Address = "3323 SE Loop 289, Lubbock, TX 79404", Phone = "(806) 775-2057" },
                new Shelter { Id = 2, Name = "Haven Animal Care Shelter", Address = "4501 Farm to Market Rd 1729, Lubbock, TX 79403", Phone = "(806) 763-0092" }
                );

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Chewie", Age = 2, Type = "Dog", ShelterId = 1 },
                new Animal { Id = 2, Name = "Han", Age = 7, Type = "Dog", ShelterId = 2 }
                );
        }


    }
}
