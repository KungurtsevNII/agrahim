using System.Diagnostics;
using System.Threading.Tasks;
using Agrahim.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Agrahim.API.Controllers
{
    [Route("")]
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<UserEntity> _signInManager;
        
        public HomeController(ILogger<HomeController> logger, SignInManager<UserEntity> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }
        
        [Route("")]
        [Route("index")]
        public IActionResult Index() => View();

        [HttpGet("privacy")]
        public IActionResult Privacy() => View();

        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index");
            return View(new LoginViewModel { ReturnUrl = returnUrl });;
        }

        [HttpGet("access-denied")]
        public IActionResult AccessDenied() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                // проверяем, принадлежит ли URL приложению
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }

            return View(model);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}