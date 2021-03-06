using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.HtmlControls;
namespace Foundation.Controls.Controls
{
    public class VariantSelectionControl : Control
    {
        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            var associatedVariants = GetAssociatedVariants();
            var keyValuePairs = associatedVariants.Any()
                ? associatedVariants.Select(i => new KeyValuePair<string, string>(i.Name, i.ID.ToString())).ToList()
                : new List<KeyValuePair<string, string>>();
            output.Write("<select" + ControlAttributes + ">");
            foreach (var keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Value == Value)
                {
                    output.Write($"<option value=\"{keyValuePair.Value}\" selected=\"selected\">{keyValuePair.Key}</option>");
                }
                else
                {
                    output.Write($"<option value=\"{keyValuePair.Value}\">{keyValuePair.Key}</option>");
                }
            }
            output.Write("</select>");
        }
        protected override bool LoadPostData(string value)
        {
            if (value == null)
                return false;
            if (this.GetViewStateString("Value") != value)
                Sitecore.Context.ClientPage.Modified = true;
            this.SetViewStateString("Value", value);
            return true;
        }
        private IEnumerable<Item> GetAssociatedVariants()
        {
            var renderingSettingItem = GetRenderingSettingItem();
            var selectedRenderingVariantDefinition = new ReferenceField(renderingSettingItem.Fields[Templates.LocalizedRenderingVariantSetting.Fields.RenderingVariantDefinitionId]).TargetItem;
            return selectedRenderingVariantDefinition.Children;            
        }
        private Item GetRenderingSettingItem()
        {
            var currentItemRegex = new Regex(@"\{(.*?)\}");
            return Sitecore.Context.ContentDatabase.GetItem(new ID(currentItemRegex.Match(ControlAttributes).Value)).Parent;
        }        
    }
}