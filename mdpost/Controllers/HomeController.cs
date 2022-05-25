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

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var path = $"~/posts/index.md";
            HomeViewModel homeModel = new();
            if (!System.IO.File.Exists(Path.Combine(_environment.WebRootPath, path.Substring(2))))
            {
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
                {
                    Title = "Error",
                    Code = 404,
                    Message = "Index file not found!",
                    Description = "Create a file named index.md in the /wwwroot/posts folder."
                });
            }
            homeModel.Path = path;
            homeModel.Title = "";
            return View(homeModel);
        }

        [Route("{mdname}")]
        public IActionResult Index(string mdname)
        {
            HomeViewModel homeModel = new();
            var path = $"~/posts/{mdname}.md";
            ViewData["MarkdownFile"] = path;
            if (!System.IO.File.Exists(Path.Combine(_environment.WebRootPath, path.Substring(2))))
            {
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
                {
                    Title = "Error",
                    Code = 404,
                    Message = "File not found!",
                    Description = "Can't find specified file"
                });
            }
            string filename = path.Substring(2).Replace("posts/", "").Replace(".md", "");
            filename = filename[0].ToString().ToUpper() + filename.Substring(1);
            filename = filename.Replace('_', ' ');
            homeModel.Title = filename;
            homeModel.Path = path;
            return View(homeModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
