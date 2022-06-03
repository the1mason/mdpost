using mdpost.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace mdpost.Controllers;
public class HomeController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public HomeController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [Route("{**mdname}")]
    public IActionResult Index(string mdname)
    {
        if (mdname == null)
            mdname = "index";
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
        string filename = "";
        if (mdname != "index")
        {
            filename = path.Substring(2).Replace("posts/", "").Replace(".md", "");
            filename = filename[0].ToString().ToUpper() + filename.Substring(1);
            filename = filename.Replace('_', ' ');
        }
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
