using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Agrahim.Infrastructure
{
    public class AgrahimContextFactory : IDesignTimeDbContextFactory<AgrahimContext>
    {
        public AgrahimContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgrahimContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-TD5K0AB1\\SQLEXPRESS;Database=agrahim_db;Trusted_Connection=True; User Id=sa; Password=123123123;");

            return new AgrahimContext(optionsBuilder.Options);
        }
    }
}