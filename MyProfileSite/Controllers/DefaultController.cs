using MyProfileSite.Web.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace MyProfileSite.Web.Controllers
{
    public class DefaultController : RenderMvcController
    {
        public ActionResult Index(BasePageViewModel baseModel)
        {
            return CurrentTemplate(baseModel);
        }
    }
}