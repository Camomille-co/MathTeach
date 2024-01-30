using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MathDbContext : DbContext
    {
        public MathDbContext(DbContextOptions<MathDbContext> options) : base(options)
        {

        }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Performance> Performances { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<User> Users { get; set; }  
    }

        public class MathDbContextFactory : IDesignTimeDbContextFactory<MathDbContext>
        {
            public MathDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MathDbContext>();

                optionsBuilder.UseSqlServer(@"Server=DESKTOP-RR0CBRF;Database=MathTeach;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True", b => b.MigrationsAssembly("DataLayer"));

                return new MathDbContext(optionsBuilder.Options);
            }
        }
    
}
