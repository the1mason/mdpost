using mdpost.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
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
        
        var path = $"~/posts/{mdname}.md";
        
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
        string bc = "";

        if (mdname != "index")
        {
            filename = Utils.StringUtil.TitleFromFilename(path);
            bc = Utils.StringUtil.BreadcrumbsHTMLFromFilename(path);
        }

        HomeViewModel homeModel = new()
        {
            Title = filename,
            Path = path,
            breadcrumbs = bc
        };
        
        return View(homeModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
