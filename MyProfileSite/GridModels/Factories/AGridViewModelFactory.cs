using MyProfileSite.Web.GridModels.GridItemValues;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Templates;

namespace MyProfileSite.Web.GridModels
{
    public class AGridViewModelFactory
    {
        public AGridViewModel CreateGridViewModel(IPublishedContent content, string alias)
        {
            var gridData = content.GetPropertyValue<GridDataModel>(alias);

            var viewModel = new AGridViewModel();

            if (gridData?.Sections == null)
                return viewModel;

            foreach (var section in gridData.Sections)
            {
                //add section
                var sectionVm = new AGridSectionViewModel()
                {
                    GridSize = section.Grid
                };

                viewModel.Sections.Add(sectionVm);


                //add rows to section
                foreach (var row in section.Rows)
                {
                    var rowVm = new AGridRowViewModel()
                    {
                        Name = row.Name
                    };
                    sectionVm.Rows.Add(rowVm);

                    //add column to row
                    foreach (var column in row.Areas)
                    {
                        var columnVm = new AGridColumnViewModel()
                        {
                            Size = column.Grid
                        };
                        rowVm.Columns.Add(columnVm);

                        //add items to column
                        foreach (var item in column.Controls)
                        {
                            var itemVm = new AGridItemViewModel()
                            {
                                Name = item.Editor.Name,
                                Alias = item.Editor.Alias,
                                Value = ConvertToGridItemValue(item)
                            };
                            columnVm.Items.Add(itemVm);

                        }
                    }
                }
            }


            return viewModel;
        }


        private static IGridItemValue ConvertToGridItemValue(GridControl control)
        {
            switch (control.Editor.Alias)
            {
                case "rte":
                    return CreateRteGridItemValue(control);
                case "imageBanner":
                    return CreateImageBannerGridItemValue(control);
                case "media":
                    return CreateImageGridItemValue(control);
            }

            return null;
        }

        private static IGridItemValue CreateImageGridItemValue(GridControl control)
        {
            var media = control.GetValue<GridControlMediaValue>();

            if (string.IsNullOrWhiteSpace(media?.Image))
            {
                return null;
            }

            var helper = new UmbracoHelper(UmbracoContext.Current);
            var image = helper.TypedMedia(media.Id);

            if (image == null)
            {
                return null;
            }

            return new ImageGridItemValue
            {
                ImageUrl = image.Url,
                AltText = media.AlternativeText
            };
        }

        private static ImageBannerGridItemValue CreateImageBannerGridItemValue(GridControl control)
        {
            var media = control.JObject.GetValue("value");
            var id = media.Value<int>("id");

            var helper = new UmbracoHelper(UmbracoContext.Current);
            var image = helper.TypedMedia(id);

            if (image == null)
            {
                return null;
            }

            return new ImageBannerGridItemValue
            {
                ImageUrl = image.Url,
                Title = media.Value<string>("title"),
                Subtitle = media.Value<string>("subtitle")
            };
        }

        private static RteGridItemValue CreateRteGridItemValue(GridControl control)
        {
            var htmlValue = control.GetValue<GridControlHtmlValue>().HtmlValue;
            var htmlValueWithLocalLinksParsed = htmlValue != null ? TemplateUtilities.ParseInternalLinks(htmlValue.ToHtmlString() ?? "") : "";

            return new RteGridItemValue
            {
                HtmlString = new HtmlString(htmlValueWithLocalLinksParsed)
            };
        }
    }
}