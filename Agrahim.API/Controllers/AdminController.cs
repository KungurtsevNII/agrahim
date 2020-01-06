using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.ViewModels;
using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.API.Controllers
{
    [Route("admin")]
    [Authorize(Roles = UserEntity.RoleAdmin)]
    public class AdminController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;

        public AdminController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("users")]
        public async Task<IActionResult> GetUsers(CancellationToken ct)
        {
            var result = await _userManager.Users.ToListAsync(ct);
            return View(result);
        }
        
        [HttpGet]
        [Route("users/create")]
        public IActionResult CreateUser() => View();
        
        [HttpPost, ValidateAntiForgeryToken]
        [Route("users/create")]
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
            
            return RedirectToAction("GetUsers", "Admin");
        }
    }
}