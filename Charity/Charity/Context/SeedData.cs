using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Models.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Charity.Context
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN"}
            );
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER"}
            );
            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "ubrania, które nadają się do ponownego użycia" },
                 new Category { Id = 2, Name = "ubrania, do wyrzucenia" },
                 new Category { Id = 3, Name = "zabawki" },
                 new Category { Id = 4, Name = "książki" },
                 new Category { Id = 5, Name = "inne" }
             );
            modelBuilder.Entity<Institution>().HasData(
                new Institution { Id = 1, Name = "Cel i misja: Pomoc dla osób nie posiadających miejsca zamieszkania", Description = "Fundacja \"Bez domu\"" },
                new Institution { Id = 2, Name = "Cel i misja: Pomoc osobom znajdującym się w trudnej sytuacji życiowej", Description = "Fundacja \"Dla dzieci\"" }
            );
        }
    }
}
