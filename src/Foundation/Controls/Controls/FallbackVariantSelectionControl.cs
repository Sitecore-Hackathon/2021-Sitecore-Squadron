﻿using System.Collections.Generic;
using System.Linq;
using Foundation.Controls.Helpers;
using Sitecore.Web.UI.HtmlControls;

namespace Foundation.Controls.Controls
{
    public class FallbackVariantSelectionControl : Control
    {
        protected override void DoRender(System.Web.UI.HtmlTextWriter output)
        {
            var associatedVariants = VariantControlsHelper.GetAssociatedVariants(ControlAttributes, false);
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
    }
}