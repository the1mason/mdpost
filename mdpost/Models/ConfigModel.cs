using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mdpost.Models
{
    public class ConfigModel
    {
        public string AppName { get; set; }
        public List<(string text, string link)> MenuItems { get; set; }
        public string[] AppUrls { get; set; }
    }
}
