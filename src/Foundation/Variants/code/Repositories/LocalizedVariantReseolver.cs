using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Variants.Repositories
{
    public class LocalizedVariantReseolver : ILocalizedVariantResolver
    {
        public Item ResolveLocalizedVariantFromMagicVariant(Item magicVariantDefintion, bool enableFallback = true, bool logFallbackAsError = true)
        {
            // [LASTER.J:2021-03-05] TODO: Here is where we need to do localization logic
            Sitecore.Diagnostics.Log.Info("Localized data template detected!", this);
            Sitecore.Diagnostics.Log.Info($"Parent is: {magicVariantDefintion.Parent?.Paths.FullPath}", this);

            var variants = new List<SearchResultItem>();
            var indexable = new SitecoreIndexableItem(magicVariantDefintion);
            using (var searchContext = ContentSearchManager.GetIndex(indexable).CreateSearchContext())
            {
                variants = searchContext.GetQueryable<SearchResultItem>()
                                    .Where(i => i.Paths.Contains(magicVariantDefintion.ParentID) && i.TemplateId == Templates.VariantDefinition.Id)
                                    .ToList();
            }

            // [LASTER.J:2021-03-05] When configuration items are in place, log this error if there's no fallback in place.
            if (variants?.Any() == false)
            {
                Sitecore.Diagnostics.Log.Error($"[L.VARIANT] Attempting to localize magica variant defintion but no associated, localized defintions discovered in index. " +
                    $"ID: \"{magicVariantDefintion.ID}\" Path:\"{magicVariantDefintion.Paths.FullPath}\"", this);
            }

            var randomVariant = new Random().Next(variants.Count);
            return variants[randomVariant].GetItem();
        }
    }
}