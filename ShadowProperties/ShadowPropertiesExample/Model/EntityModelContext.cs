using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ShadowProperties.Model
{
    public class EntityModelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=Test;user Id=sa; password=Passwd@12;");

            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property<DateTime>("CreatedDate");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
