using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.XA.Foundation.SitecoreExtensions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Variants.Repositories
{
    public class LocalizedVariantContentRepository : Sitecore.XA.Foundation.SitecoreExtensions.Repositories.ContentRepository, IContentRepository
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly ILocalizedVariantResolver _localizedVariantResolver;

        public LocalizedVariantContentRepository(IDatabaseRepository databaseRepository, ILocalizedVariantResolver localizedVariantResolver) : base(databaseRepository)
        {
            this._databaseRepository = databaseRepository;
            this._localizedVariantResolver = localizedVariantResolver;
        }

        public new Item GetItem(ID id)
        {
            var item = base.GetItem(id);
            if (item == null)
            {
                return item;
            }

            var template = TemplateManager.GetTemplate(item);
            if (template == null)
            {
                return item;
            }

            if (template.InheritsFrom(Templates.LocalizedVariantDefinition.Id))
            {
                if (Sitecore.Context.PageMode.IsExperienceEditorEditing)
                {
                    return null;
                }

                return this._localizedVariantResolver.ResolveLocalizedVariantFromMagicVariant(item);
            }

            return item;
        }
    }
}