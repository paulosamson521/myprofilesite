using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileSite.Web.GridModels
{
    public class AGridViewModel
    {
        public IList<AGridSectionViewModel> Sections { get; private set; }

        public int WrapperCols { get; set; }

        public int WrapperOffset { get; set; }

        public AGridViewModel()
        {
            Sections = new List<AGridSectionViewModel>();
        }
    }
}