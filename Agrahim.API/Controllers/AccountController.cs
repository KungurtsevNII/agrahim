using System.Threading.Tasks;
using Agrahim.Common.ViewModels;
using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agrahim.API.Controllers
{
    [Route("account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;

        public AccountController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("change-password")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user is null)
            {
                return BadRequest("Пользователь не найден");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);

            // Если изменение закончилось с ошибками, то сохраняем их в модель.
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            }
            
            return View("Index");
        }
    }
}