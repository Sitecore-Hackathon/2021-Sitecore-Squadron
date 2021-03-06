using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Foundation.Controls.Helpers
{
    public static class VariantControlsHelper
    {
        public static IEnumerable<Item> GetAssociatedVariants(string controlAttributes, bool variantDefinitionSelectedOnParent = false)
        {
            var renderingSettingItem = GetRenderingSettingItem(controlAttributes, variantDefinitionSelectedOnParent);
            var selectedRenderingVariantDefinition = new ReferenceField(renderingSettingItem.Fields[Templates.LocalizedRenderingVariantSetting.Fields.RenderingVariantDefinitionId]).TargetItem;            
            if (selectedRenderingVariantDefinition != null)
            {
                return selectedRenderingVariantDefinition.Children;
            }
            else
            {
                return new List<Item>();
            }
        }

        public static Item GetRenderingSettingItem(string controlAttributes, bool variantDefinitionSelectedOnParent = false)
        {
            var currentItemRegex = new Regex(@"\{(.*?)\}");
            return (variantDefinitionSelectedOnParent) 
                ? Context.ContentDatabase.GetItem(new ID(currentItemRegex.Match(controlAttributes).Value)).Parent
                : Context.ContentDatabase.GetItem(new ID(currentItemRegex.Match(controlAttributes).Value));
        }        
    }
}
