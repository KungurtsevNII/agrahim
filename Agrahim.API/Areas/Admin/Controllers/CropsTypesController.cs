using System;
using System.Threading;
using System.Threading.Tasks;
using Agrahim.Common.ViewModels;
using Agrahim.Domain.ServicesContracts;
using Agrahim.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.API.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/crops-types")]
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

            if (!_cropsTypesService.IsUniq(model.Name))
            {
                ModelState.AddModelError("", "Название культуры должны быть уникальным.");
                return View();
            }
            
            await _cropsTypesService.Create(model.Name, ct);
            return RedirectToAction("Index");
        }
    }
}