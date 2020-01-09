using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.Infrastructure
{
    public class AgrahimContext : IdentityDbContext<UserEntity>
    {
        public DbSet<CropsTypeEntity> CropsTypes { get; set; }
        
        public AgrahimContext(DbContextOptions<AgrahimContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CropsTypeEntity>()
                .Property(ct => ct.NormalizedName)
                .HasComputedColumnSql("UPPER([Name])");
            
            builder.Entity<CropsTypeEntity>().HasAlternateKey(ct => ct.NormalizedName);
                
        }
    }
}