using System.Collections.Generic;
using System.Linq;

namespace MyProfileSite.Web.GridModels
{
    public class AGridRowViewModel
    {
        public IList<AGridColumnViewModel> Columns { get; private set; }

        public string Name { get; set; }
        public string Alias { get; set; }

        public AGridRowViewModel()
        {
            Columns = new List<AGridColumnViewModel>();
        }

     
    }
}