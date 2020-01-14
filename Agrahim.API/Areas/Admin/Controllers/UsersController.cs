using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.ViewModels;
using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.API.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/users")]
    [Authorize(Roles = UserEntity.RoleAdmin)]
    public class UsersController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;

        public UsersController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        [Route("index")]
        [Route("")]
        public async Task<IActionResult> GetUsers(CancellationToken ct)
        {
            var result = await _userManager.Users.ToListAsync(ct);
            return View(result);
        }
        
        [HttpGet]
        [Route("create")]
        public IActionResult CreateUser() => View();
        
        [HttpPost, ValidateAntiForgeryToken]
        [Route("create")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            // Валидация модели
            if (!ModelState.IsValid) return View();
            
            UserEntity user = new UserEntity { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            
            // Если создание закончилось с ошибками, то сохраняем их в модель.
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, UserEntity.RoleUser);
            
            if (!addToRoleResult.Succeeded)
            {
                foreach (var error in addToRoleResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            
            return RedirectToAction("GetUsers", "Users");
        }
    }
}