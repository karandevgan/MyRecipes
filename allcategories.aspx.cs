using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class allcategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Image_Command(object sender, CommandEventArgs e)
    {
        string Category = e.CommandArgument.ToString();
        Response.Redirect("~\\showcategory.aspx?Category=" + Category);
    }
}