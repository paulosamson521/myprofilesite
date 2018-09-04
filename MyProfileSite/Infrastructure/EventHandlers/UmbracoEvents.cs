using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web.Mvc;

namespace MyProfileSite.Web.Infrastructure.EventHandlers
{
    public class UmbracoEvents : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //events on initialized
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //events on app started
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //Set default controller for all the page types
            DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(Controllers.DefaultController));
        }
    }
}