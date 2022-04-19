using System;

namespace mdpost.Models
{
    public class ErrorViewModel : HomeViewModel
    {

        public int? Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
