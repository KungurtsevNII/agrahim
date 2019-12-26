using Agrahim.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.Infrastructure
{
    public class AgrahimContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        
        public AgrahimContext(DbContextOptions<AgrahimContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}