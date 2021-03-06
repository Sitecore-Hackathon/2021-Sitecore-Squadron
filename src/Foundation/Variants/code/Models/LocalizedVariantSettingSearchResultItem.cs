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
    public class LocalizedVariantSettingSearchResultItem : SearchResultItem
    {
        [IndexField("rendering_variant_definition")]
        public List<Guid> RenderingVariantDefinition { get; set; }

        [IndexField("user_distance")]
        public long UserDistance { get; set; }

        [IndexField("fallback_variant")]
        public string FallbackVariant { get; set; }
    }
}