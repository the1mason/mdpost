using mdpost.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            ViewData["MarkdownFile"] = "~/posts/index.md";
            return View();
        }

        [Route("{mdname}")]
        public IActionResult Index(string mdname)
        {
            var path = "~/posts/" + mdname + ".md";
            if (!System.IO.File.Exists($"{_environment.WebRootPath}/posts/{mdname}.md"))
            {
                return StatusCode(404);
            }
            ViewData["MarkdownFile"] = path;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
