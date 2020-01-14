using System;
using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.ViewModels;
using Agrahim.Common.ViewModels.CropsType;
using Agrahim.Domain.ServicesContracts;
using Agrahim.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agrahim.API.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/crops-types")]
    [Authorize(Roles = UserEntity.RoleAdmin)]
    public class CropsTypesController : Controller
    {
        private readonly ICropsTypesService _cropsTypesService;

        public CropsTypesController(ICropsTypesService cropsTypesService)
        {
            _cropsTypesService = cropsTypesService;
        }

        [Route("")]
        [Route("index")]
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken ct = default)
        {
            var cropsTypes = await _cropsTypesService.GetAll(ct);
            return View(cropsTypes);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateCropsTypeViewModel model, CancellationToken ct = default)
        {
            // Валидация модели
            if (!ModelState.IsValid) return View();

            if (!await _cropsTypesService.IsUniq(model.Name, ct))
            {
                ModelState.AddModelError("", "Название культуры должны быть уникальным.");
                return View();
            }
            
            await _cropsTypesService.Create(model, ct);
            return RedirectToAction("Index");
        }

        [HttpGet("disable/{id}")]
        public async Task<IActionResult> Disable(long id, CancellationToken ct)
        {
            await _cropsTypesService.Disable(id, ct);
            return RedirectToAction("Index");
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(long id, CancellationToken ct)
        {
            var cropsType = await _cropsTypesService.GetById(id, ct);
            return View(cropsType);
        }
        
        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(UpdateCropsTypeViewModel model, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _cropsTypesService.Update(model, ct);
            return RedirectToAction("Index");
        }
    }
}