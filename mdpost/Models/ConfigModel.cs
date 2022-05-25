using System.Collections.Generic;

namespace mdpost.Models;
public class ConfigModel
{
    public string AppName { get; set; }
    public List<(string text, string link)> MenuItems { get; set; }
    public string[] AppUrls { get; set; }
}
