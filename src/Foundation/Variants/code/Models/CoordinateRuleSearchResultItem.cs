using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.ContentSearch.Data;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Foundation.Variants.Models
{
    public class CoordinateRuleSearchResultItem : SearchResultItem
    {
        [IndexField("rendering_variant")]
        public string RenderingVariantDefinition { get; set; }
    }
}