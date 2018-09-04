using System.Collections.Generic;

namespace MyProfileSite.Web.GridModels
{
    public class AGridSectionViewModel
    {
        public IList<AGridRowViewModel> Rows { get; private set; }
        public int GridSize { get; set; }

        public AGridSectionViewModel()
        {
            Rows = new List<AGridRowViewModel>();
        }
    }
}