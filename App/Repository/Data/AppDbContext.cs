using Domain.Configurations;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bunlari ona gore yaziriqki basaya modeli qoyanda Configurationlarda yazdigimiz konstrentleri nezere alsin !

            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Bu butun konstrenleri yukleyir bura !!


            modelBuilder.Entity<Employee>().HasData(
          new Employee
          {
              Id = 1,
              FullName = "Roya Meherremova",
              Address = "Sumqayit",
              Age = 27
          },

          new Employee
          {
              Id = 2,
              FullName = "Anar Eliyev",
              Address = "Xetai",
              Age = 28
          },

          new Employee
          {
              Id = 3,
              FullName = "Mubariz Agayev",
              Address = "Nesimi",
              Age = 18
          }
          );

        }
    }
}
