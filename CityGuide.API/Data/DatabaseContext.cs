using CityGuide.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide.API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<Value> Values{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
