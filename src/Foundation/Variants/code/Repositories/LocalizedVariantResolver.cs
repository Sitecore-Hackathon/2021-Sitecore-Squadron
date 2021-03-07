using Foundation.Variants.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Data;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Sitecore.XA.Foundation.Presentation;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Variants.Repositories
{
    public class LocalizedVariantResolver : ILocalizedVariantResolver
    {
        private readonly IPresentationContext _presentationContext;

        public LocalizedVariantResolver(IPresentationContext presentationContext)
        {
            this._presentationContext = presentationContext;
        }

        public Item ResolveLocalizedVariantFromMagicVariant(Item magicVariantDefintion, bool enableFallback = true, bool logFallbackAsError = true)
        {
            var fallBackItem = enableFallback ? null : magicVariantDefintion; // [LASTER.J] If We return null, SXA will grab the default variant (1st variant definition)
            var presentationItem = this._presentationContext.GetPresentationItem(magicVariantDefintion);
            if (presentationItem == null)
            {
                return fallBackItem;
            }

            var localizedVariantSettingsFolder = presentationItem.FirstChildInheritingFrom(Templates.LocalizedRenderingVariantSettings.Id);

            var variantSetting = new LocalizedVariantSettingSearchResultItem();
            var indexable = new SitecoreIndexableItem(magicVariantDefintion);
            var index = ContentSearchManager.GetIndex(indexable);

            using (var searchContext = index.CreateSearchContext())
            {
                variantSetting = searchContext.GetQueryable<LocalizedVariantSettingSearchResultItem>()
                                    .Where(i => i.Paths.Contains(localizedVariantSettingsFolder.ID) && i.RenderingVariantDefinition.Contains(magicVariantDefintion.ParentID.Guid))
                                    .FirstOrDefault();

                if (variantSetting != null)
                {
                    var fallbackVariantId = variantSetting.FallbackVariant;
                    fallBackItem = !string.IsNullOrWhiteSpace(fallbackVariantId) ? Sitecore.Context.Database.GetItem(fallbackVariantId) : fallBackItem;
                }
            }

            if (variantSetting == null)
            {
                Sitecore.Diagnostics.Log.Error($"[L.VARIANT] Attempting to localize magic variant defintion but no associated, localized defintions discovered in index. " +
                    $"ID: \"{magicVariantDefintion.ID}\" Path:\"{magicVariantDefintion.Paths.FullPath}\"", this);

                return fallBackItem;
            }

            // TODO: Split out into it's own function
            CoordinateRuleSearchResultItem localizedSetting = null;
            double latitude = 0.0;
            double longitude = 0.0;

            var hasLatitude = double.TryParse(HttpContext.Current.Request.QueryString["lat"], out latitude);
            var hasLongitude = double.TryParse(HttpContext.Current.Request.QueryString["lng"], out longitude);

            if (hasLatitude == false || hasLongitude == false)
            {
                return fallBackItem;
            }


            var testCoordinate = new Coordinate(latitude, longitude);
            using (var searchContext = index.CreateSearchContext())
            {
                localizedSetting = searchContext.GetQueryable<CoordinateRuleSearchResultItem>()
                                        .Where(i => i.Paths.Contains(variantSetting.ItemId))
                                        .WithinRadius(i => i.Location, testCoordinate, variantSetting.UserDistance)
                                        .FirstOrDefault();

                if (localizedSetting != null)
                {
                    //{4626EE00-2461-4F13-9180-273B3903EA33} == "Rendering To Display" -> Rendering Variant
                    var idOfVariant = localizedSetting.RenderingVariantDefinition;
                    if (!string.IsNullOrWhiteSpace(idOfVariant))
                    {
                        return Sitecore.Context.Database.GetItem(new Sitecore.Data.ID(idOfVariant));
                    }
                }
            }

            return fallBackItem;
        }
    }
}