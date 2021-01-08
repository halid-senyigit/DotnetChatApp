using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetChatApp.Models;
using DotnetChatApp.Database;
using Microsoft.EntityFrameworkCore;

namespace DotnetChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext db;

        public HomeController(ILogger<HomeController> logger, ModelContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var messages = db.Messages.Include(n => n.User).ToList();
            return View(messages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
