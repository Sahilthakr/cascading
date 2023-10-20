using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cascading.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<State> State{ get; set; }
        public DbSet<City> City { get; set; }
    }
        public class Country
        {
            public int CountryId { get; set; }
            public string CountryName { get; set; }
        }

        public class State
        {
            public int StateId { get; set; }
            public string StateName { get; set; }
            public int CountryId { get; set; }
        }

        public class City
        {
            public int CityId { get; set; }
            public string CityName { get; set; }
            public int StateId { get; set; }
        }

    
}
