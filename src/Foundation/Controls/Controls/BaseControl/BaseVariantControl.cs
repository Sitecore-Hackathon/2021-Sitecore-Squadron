using Sitecore.Web.UI.HtmlControls;

namespace Foundation.Controls.Controls.BaseControl
{
    public class BaseVariantControl : Control
    {
        protected override bool LoadPostData(string value)
        {
            if (value == null)
                return false;
            if (GetViewStateString("Value") != value)
                Sitecore.Context.ClientPage.Modified = true;
            SetViewStateString("Value", value);
            return true;
        }
    }
}
