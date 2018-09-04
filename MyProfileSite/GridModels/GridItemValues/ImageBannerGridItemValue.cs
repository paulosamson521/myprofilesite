using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileSite.Web.GridModels.GridItemValues
{
    public class ImageBannerGridItemValue : IGridItemValue
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}