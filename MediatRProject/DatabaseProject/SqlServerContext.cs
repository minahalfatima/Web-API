using MediatRProject.ApiFolder;
using MediatRProject.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MediatRProject.DatabaseProject
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions):base(dbContextOptions) { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Company { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeName).IsRequired();
            modelBuilder.Entity<Company>().HasKey(e => e.Id);
            modelBuilder.Entity<Company>().Property(e => e.Name).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
