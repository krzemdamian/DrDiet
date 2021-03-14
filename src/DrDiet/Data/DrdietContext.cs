using DrDiet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrDiet.Data
{
    public class DrdietContext : DbContext
    {
        public DrdietContext(DbContextOptions<DrdietContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<MenuPosition> MenuPositions { get; set; }
    }
}
