using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Foundation.Variants
{
  public struct Templates
  {
        // TODO: This template should be renamed to something more appropiate
        public struct LocalizedRenderingVariantSettings
        {
            public static readonly ID Id = new ID("{51DABDE0-FB6E-43B3-8D5E-3981F26F0DEB}");
        }

        public struct CoordinateRule
        {
            public static readonly ID Id = new ID("{F092C3D2-A737-4C23-97AB-9B6ED530CDAF}");
        }

        public struct LocalizedVariantDefinition
        {
            public static readonly ID Id = new ID("{12F8CBBE-0942-42FF-A405-989D3C86D129}");
        }
  }
}