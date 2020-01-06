using Microsoft.AspNetCore.Identity;

namespace Agrahim.Infrastructure.Entities
{
    public class UserEntity : IdentityUser
    {
        public const string AdminUserName = "Admin@server.ru";
        public const string DefaultAdminPassword = "nhjgbyrfdybrelf";

        public const string RoleAdmin = "Administrator";
        public const string RoleUser = "User";
    }
}