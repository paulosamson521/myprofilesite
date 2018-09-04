using MyProfileSite.Web.GridModels.GridItemValues;

namespace MyProfileSite.Web.GridModels
{
    public class AGridItemViewModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public IGridItemValue Value { get; set; }
    }
}