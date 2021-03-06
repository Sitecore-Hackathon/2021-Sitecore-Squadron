using Foundation.Controls.Helpers;
using Sitecore.Web.UI.HtmlControls;

namespace Foundation.Controls.Controls
{
    public class FallbackVariantSelectionControl : Control
    {
        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            var associatedVariants = VariantControlsHelper.GetAssociatedVariants(ControlAttributes, false);
            output.Write(VariantControlsHelper.OptionsToOutput(ControlAttributes, Value, VariantControlsHelper.GenerateKeyValuePairs(associatedVariants)));
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