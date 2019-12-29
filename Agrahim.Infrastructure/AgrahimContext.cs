using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.Infrastructure
{
    public class AgrahimContext : IdentityDbContext<UserEntity>
    {
        public AgrahimContext(DbContextOptions<AgrahimContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}