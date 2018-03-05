using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace TableSplittingExample.Model
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
            modelBuilder.Entity<Employee>().HasOne(p => p.EmployeeDetail).WithOne(p => p.Employee).HasForeignKey<Employee>(p => p.Id);
            modelBuilder.Entity<EmployeeDetail>().HasOne(p => p.Employee).WithOne(p => p.EmployeeDetail).HasForeignKey<EmployeeDetail>(p => p.Id);
            modelBuilder.Entity<Employee>().ToTable("Employee");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
