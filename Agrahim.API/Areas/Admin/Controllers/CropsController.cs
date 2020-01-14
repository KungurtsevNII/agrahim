using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.DTOs;
using Agrahim.Common.ViewModels.Crops;
using Agrahim.Domain.ServicesContracts;
using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agrahim.API.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/crops")]
    [Authorize(Roles = UserEntity.RoleAdmin)]
    public class CropsController : Controller
    {
        private readonly ICropsService _cropsService;

        public CropsController(ICropsService cropsService)
        {
            _cropsService = cropsService;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index(CancellationToken ct = default)
        {
            var crops = await _cropsService.GetAll(ct);
            return View(crops);
        }

        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create(CancellationToken ct = default)
        {
            await PopulateCropsTypesDropDownList(ct);
            return View();
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateCropViewModel model, CancellationToken ct = default)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCropsTypesDropDownList(ct);
                return View();
            }

            if (!await _cropsService.IsUniq(model.Name, ct))
            {
                ModelState.AddModelError("", "Название культуры должны быть уникальным.");
                return View();
            }

            await _cropsService.Create(model, ct);            
            
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateCropsTypesDropDownList(CancellationToken ct = default)
        {
            var cropsTypes = await _cropsService.GetCropsTypeToSelect(ct);
            ViewBag.CropsTypes = new SelectList(
                cropsTypes, 
                nameof(CropsTypeToSelectDto.Id),
                nameof(CropsTypeToSelectDto.Name));
        }
    }
}