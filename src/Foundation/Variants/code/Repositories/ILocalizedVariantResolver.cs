using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation.Variants.Repositories
{
    public interface ILocalizedVariantResolver
    {
        Item ResolveLocalizedVariantFromMagicVariant(Item magicVariantDefintion, bool enableFallback = true, bool logFallbackAsError = true);    
    }
}
