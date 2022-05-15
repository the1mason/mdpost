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
            HomeViewModel lhvm = new();
            lhvm = hvm;
            if (!System.IO.File.Exists(Path.Combine(_environment.WebRootPath, path.Substring(2))))
            {
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
                {
                    MenuItems = lhvm.MenuItems,
                    AppName = lhvm.AppName,
                    Title = "Error",
                    Code = 404,
                    Message = "Index file not found!",
                    Description = "Can't find index.md file"
                });
            }
            lhvm.Path = path;
            string filename = path.Substring(2).Replace("posts/", "").Replace(".md", "");
            filename = filename.Replace(filename[0], char.ToUpper(filename[0]));
            lhvm.Title = filename;
            return View(lhvm);
        }

        [Route("{mdname}")]
        public IActionResult Index(string mdname)
        {
            HomeViewModel lhvm = new();
            lhvm = hvm;
            var path = $"~/posts/{mdname}.md";
            ViewData["MarkdownFile"] = path;
            if (!System.IO.File.Exists(Path.Combine(_environment.WebRootPath, path.Substring(2))))
            {
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
                {
                    MenuItems = lhvm.MenuItems,
                    AppName = lhvm.AppName,
                    Title = "Error",
                    Code = 404,
                    Message = "File not found!",
                    Description = "Can't find specified file"
                });
            }
            string filename = path.Substring(2).Replace("posts/", "").Replace(".md", "");
            filename = filename[0].ToString().ToUpper() + filename.Substring(1);
            filename = filename.Replace('_', ' ');
            lhvm.Title = filename;
            lhvm.Path = path;
            return View(lhvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
