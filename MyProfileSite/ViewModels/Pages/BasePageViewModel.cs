using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedContentModels;
using Umbraco.Web;
using MyProfileSite.Web.Infrastructure.Extensions;
using MyProfileSite.Web.GridModels;

namespace MyProfileSite.Web.ViewModels.Pages
{
    public class BasePageViewModel : RenderModel
    {
        public BasePageViewModel() 
            : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
        { }

        public BasePageViewModel(IPublishedContent content, CultureInfo culture) 
            : base(content, culture)
        {
        }

        private HomePage _homePage;
        private HomePage HomePage => _homePage ?? (_homePage = Content.GetHomePage());

        public IThirdPartyScripts ThirdPartyScripts => HomePage as IThirdPartyScripts;

        AGridViewModel _grid;
        public AGridViewModel Grid => _grid ?? (_grid = Content.GetGridViewModel("grid"));

        HeaderViewModel _header;
        public HeaderViewModel Header
        {
            get
            {
                if (_header != null)
                    return _header;

                _header = new HeaderViewModel();

                //get visible pages under home page
                var menus = new MenuItemViewModel[] { HomePage.ToMenuItemViewModel(Content) };
                _header.MenuItems =  menus.Concat(HomePage.GetChildrenAsMenuItems(Content));
                

                return _header;
            }
        }
    }
}