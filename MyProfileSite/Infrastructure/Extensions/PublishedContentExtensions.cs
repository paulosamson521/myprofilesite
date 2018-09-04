using MyProfileSite.Web.GridModels;
using MyProfileSite.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.PublishedContentModels;

namespace MyProfileSite.Web.Infrastructure.Extensions
{
    public static class PublishedContentExtensions
    {
        /// <summary>
        /// gets the home node for the current page, 
        /// then save it to httpcontext.items for later retrieval of other modules/functions that might use it on the same page request
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static HomePage GetHomePage(this IPublishedContent content)
        {
            const string HomePageCacheKey = "MyProfileSite.HomePage";

            var ctx = UmbracoContext.Current.HttpContext;

            if (ctx.Items.Contains(HomePageCacheKey))
                return (HomePage)ctx.Items[HomePageCacheKey];

            var homePage = content.Site().OfType<HomePage>();
            ctx.Items.Add(HomePageCacheKey, homePage);

            return homePage;
        }


        /// <summary>
        /// gets the grid view model for the current page
        /// </summary>
        /// <param name="content"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public static AGridViewModel GetGridViewModel(this IPublishedContent content, string alias)
        {
            return new AGridViewModelFactory().CreateGridViewModel(content, alias);
        }


        /// <summary>
        /// gets children of the current page as menu tems
        /// </summary>
        /// <param name="content"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public static IEnumerable<MenuItemViewModel> GetChildrenAsMenuItems(this IPublishedContent content, IPublishedContent currentPage)
        {
            return content.Children
                    .Where(x => x.IsVisible())
                    .Select(x=> x.ToMenuItemViewModel(currentPage));
        }

        public static MenuItemViewModel ToMenuItemViewModel(this IPublishedContent content, IPublishedContent currentPage)
        {
            var pageOptions = content.OfType<IPageOptions>();
            var title = string.IsNullOrEmpty(pageOptions.MenuTitle) ? content.Name : pageOptions.MenuTitle;

            return new MenuItemViewModel()
            {
                Name = title,
                IsCurrent = currentPage.Id == content.Id,
                Url = content.Url
            };
        }
    }
}