using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace MyProfileSite.Web.ViewModels
{
    public class HeaderViewModel
    {
        public IEnumerable<MenuItemViewModel> MenuItems { get; set; }
    }

    public class MenuItemViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsCurrent { get; set; }
    }
}