using Microsoft.EntityFrameworkCore;
using SessionMVC850.Models;

namespace SessionMVC850.Context
{
    public class CompanyContext:DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(

                "Server=localhost;Database=Session850;Trusted_Connection=True;TrustServerCertificate=True;");
        }


    }
}
