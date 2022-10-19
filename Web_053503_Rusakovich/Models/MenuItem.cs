using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Web_053503_Rusakovich.Models
{
    public class MenuItem
    {
        public  bool IsPage { get; set; }
        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Page { get; set; }
        public string Area { get; set; }
        public string Active { get; set; }
    }
}
