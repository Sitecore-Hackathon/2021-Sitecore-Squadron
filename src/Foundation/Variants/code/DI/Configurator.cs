using Foundation.Variants.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.SitecoreExtensions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Variants.DI
{
    public class Configurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IContentRepository, LocalizedVariantContentRepository>();
            serviceCollection.AddTransient<ILocalizedVariantResolver, LocalizedVariantResolver>();
        }
    }
}