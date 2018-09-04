using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileSite.Web.GridModels.GridItemValues
{
    public class ImageGridItemValue : IGridItemValue
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
    }
}