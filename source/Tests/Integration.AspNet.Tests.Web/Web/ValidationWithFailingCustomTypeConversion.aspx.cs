using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void CustomConvert(object sender, ValueConvertEventArgs args)
    {
        args.ConversionErrorMessage = "custom conversion error message";
    }
}
