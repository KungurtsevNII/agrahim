using System.Threading.Tasks;
using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Agrahim.Infrastructure
{
    public class AgrahimContextInitializer
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AgrahimContextInitializer(
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            await InitializeIdentityAsync();
        }

        private async Task InitializeIdentityAsync()
        {
            if (!await _roleManager.RoleExistsAsync(UserEntity.RoleUser))
                await _roleManager.CreateAsync(new IdentityRole(UserEntity.RoleUser));

            if (!await _roleManager.RoleExistsAsync(UserEntity.RoleAdmin))
                await _roleManager.CreateAsync(new IdentityRole(UserEntity.RoleAdmin));

            if (await _userManager.FindByNameAsync(UserEntity.AdminUserName) == null)
            {
                var admin = new UserEntity
                {
                    UserName = UserEntity.AdminUserName,
                    Email = UserEntity.AdminUserName
                };

                var creation_result = await _userManager.CreateAsync(admin, UserEntity.DefaultAdminPassword);

                if (creation_result.Succeeded)
                    await _userManager.AddToRoleAsync(admin, UserEntity.RoleAdmin);
            }
        }
    }
}