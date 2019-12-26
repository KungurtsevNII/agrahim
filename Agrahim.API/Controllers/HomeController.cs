using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Agrahim.API.Models;
using Agrahim.Infrastructure;
using Agrahim.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agrahim.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AgrahimContext _context;

        public HomeController(ILogger<HomeController> logger, AgrahimContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await _context.Orders.AddAsync(new OrderEntity
            {
                Count = 3,
                UserName = "Nekit"
            });
            await _context.Orders.AddAsync(new OrderEntity
            {
                Count = 3,
                UserName = "Diman"
            });
            await _context.Orders.AddAsync(new OrderEntity
            {
                Count = 3,
                UserName = "Andrei"
            });
            await _context.Orders.AddAsync(new OrderEntity
            {
                Count = 3,
                UserName = "Lox"
            });
            await _context.Orders.AddAsync(new OrderEntity
            {
                Count = 3,
                UserName = "Pidr"
            });
            await _context.SaveChangesAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("get-orders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _context.Orders.ToListAsync();
            return View(result);
        }

        [HttpGet("get-my-orders")]
        public async Task<IActionResult> GetMyOrders()
        {
            var result = await _context.Orders.Where(x => x.UserName == "Nekit").ToListAsync();
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}