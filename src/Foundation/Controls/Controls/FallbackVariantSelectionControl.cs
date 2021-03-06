using Foundation.Controls.Controls.BaseControl;
using Foundation.Controls.Helpers;

namespace Foundation.Controls.Controls
{
    public class FallbackVariantSelectionControl : BaseVariantControl
    {
        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            var associatedVariants = VariantControlsHelper.GetAssociatedVariants(ControlAttributes, false);
            output.Write(VariantControlsHelper.OptionsToOutput(ControlAttributes, Value, VariantControlsHelper.GenerateKeyValuePairs(associatedVariants)));
        }            
    }
}