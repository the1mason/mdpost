using mdpost.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mdpost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;
        private HomeViewModel hvm;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
            hvm = new();
            hvm.AppName = Program.config.AppName;
            hvm.MenuItems = Program.config.MenuItems;
        }

        public IActionResult Index()
        {
            var path = $"~/posts/index.md";

            if (!System.IO.File.Exists(Path.Combine(_environment.WebRootPath, path.Substring(2))))
            {
                return NotFound();
            }
            hvm.Path = path;
            hvm.Title = path.Substring(2);
            return View(hvm);
        }

        [Route("{mdname}")]
        public IActionResult Index(string mdname)
        {
            var path = $"~/posts/{mdname}.md";
            ViewData["MarkdownFile"] = path;
            if (!System.IO.File.Exists(Path.Combine(_environment.WebRootPath, path.Substring(2))))
            {
                return NotFound();
            }
            hvm.Path = path;
            return View(hvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
