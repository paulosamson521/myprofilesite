//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	// Mixin content Type 1084 with alias "content"
	/// <summary>_Content</summary>
	public partial interface IContent : IPublishedContent
	{
		/// <summary>Grid</summary>
		Skybrud.Umbraco.GridData.GridDataModel Grid { get; }
	}

	/// <summary>_Content</summary>
	[PublishedContentModel("content")]
	public partial class Content : PublishedContentModel, IContent
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "content";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Content(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Content, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Grid
		///</summary>
		[ImplementPropertyType("grid")]
		public Skybrud.Umbraco.GridData.GridDataModel Grid
		{
			get { return GetGrid(this); }
		}

		/// <summary>Static getter for Grid</summary>
		public static Skybrud.Umbraco.GridData.GridDataModel GetGrid(IContent that) { return that.GetPropertyValue<Skybrud.Umbraco.GridData.GridDataModel>("grid"); }
	}
}
