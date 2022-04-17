using System.Collections.Generic;
using System;

namespace mdpost.Models
{
    public class HomeViewModel
    {
        public string AppName { get; set; }
        public string Title { get; set; }
        public List<(string text,string link)> MenuItems { get; set; }
        public string? Path = null;
    }
}
