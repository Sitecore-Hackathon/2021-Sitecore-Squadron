using Sitecore.Data;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Variants.Pipelines.RenderRendering
{
    public class DisableCacheForLocalizedVariants : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            if (args.Rendered || !args.Cacheable)
                return;

            var fieldNames = args.Rendering.Parameters["FieldNames"];
            if (!string.IsNullOrWhiteSpace(fieldNames))
            {
                if (ID.IsID(fieldNames))
                {
                    var item = Sitecore.Context.Database.GetItem(fieldNames);
                    if (item.TemplateID == Templates.LocalizedVariantDefinition.Id)
                    {
                        args.Cacheable = false;
                        args.CacheKey = string.Empty;
                    }
                }
            }
        }
    }
}