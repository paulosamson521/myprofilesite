using MyProfileSite.Web.GridModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MyProfileSite.Web.Infrastructure.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString RenderGridItem(this HtmlHelper helper, AGridItemViewModel gridItem)
        {
            if (gridItem == null || gridItem.Value == null)
            {
                return new MvcHtmlString(string.Empty);
            }
            return helper.Partial("~/Views/Grid/" + gridItem.Alias + ".cshtml", gridItem.Value);
        }
    }
}