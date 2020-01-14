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
    [Route("[area]/home")]
    [Authorize(Roles = UserEntity.RoleAdmin)]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}