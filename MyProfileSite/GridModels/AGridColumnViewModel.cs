using System.Collections.Generic;

namespace MyProfileSite.Web.GridModels
{
    public class AGridColumnViewModel
    {
        public IList<AGridItemViewModel> Items { get; private set; }

        public string Name { get; set; }
        public string Alias { get; set; }
        public int Size { get; set; }

        public AGridColumnViewModel()
        {
            Items = new List<AGridItemViewModel>();
        }
    }
}