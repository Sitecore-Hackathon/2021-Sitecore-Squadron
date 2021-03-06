using System.Collections.Generic;
using System.Linq;
using Foundation.Controls.Helpers;
using Sitecore.Web.UI.HtmlControls;

namespace Foundation.Controls.Controls
{
    public class VariantSelectionControl : Control
    {
        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            var associatedVariants = VariantControlsHelper.GetAssociatedVariants(ControlAttributes, true);
            var keyValuePairs = associatedVariants.Any()
                ? associatedVariants.Select(i => new KeyValuePair<string, string>(i.Name, i.ID.ToString())).ToList()
                : new List<KeyValuePair<string, string>>();
            output.Write(VariantControlsHelper.OptionsToOutput(ControlAttributes, Value, keyValuePairs));
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
    }
}