using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Foundation.Controls.Helpers
{
    public static class VariantControlsHelper
    {
        public static IEnumerable<Item> GetAssociatedVariants(string controlAttributes, bool variantDefinitionSelectedOnParent = false)
        {
            var renderingSettingItem = GetRenderingSettingItem(controlAttributes, variantDefinitionSelectedOnParent);
            var selectedRenderingVariantDefinition = 
                new ReferenceField(renderingSettingItem.Fields[Templates.LocalizedRenderingVariantSetting.Fields.RenderingVariantDefinitionId]).TargetItem;            
            if (selectedRenderingVariantDefinition != null)
            {
                return selectedRenderingVariantDefinition.Children.Where(c => !c.TemplateID.ToString().Equals(Templates.LocalizeVariant.TemplateId));
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

        public static string OptionsToOutput(string controlAttributes, string selectedValue, IEnumerable<KeyValuePair<string,string>> keyValuePairs)
        {
            var optionsToOutput = "<select" + controlAttributes + ">";

            foreach (var keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Value == selectedValue)
                {
                    optionsToOutput += $"<option value=\"{keyValuePair.Value}\" selected=\"selected\">{keyValuePair.Key}</option>";
                }
                else
                {
                    optionsToOutput += $"<option value=\"{keyValuePair.Value}\">{keyValuePair.Key}</option>";
                }
            }

            optionsToOutput += "</select>";

            return optionsToOutput;
        }

        public static IEnumerable<KeyValuePair<string, string>> GenerateKeyValuePairs(IEnumerable<Item> items)
        {
            return items.Any()
                ? items.Select(i => new KeyValuePair<string, string>(i.Name, i.ID.ToString())).ToList()
                : new List<KeyValuePair<string, string>>();
        }
    }
}
