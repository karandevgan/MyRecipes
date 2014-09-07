using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminFiles_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ServicesList_Click(object sender, BulletedListEventArgs e)
    {
        switch (e.Index)
        {
            case 0:
                Response.Redirect(@"~\AdminFiles\ErrorLog.txt", true);
                break;
            case 1:
                Response.Redirect(@"~\AdminFiles\manageusers.aspx", true);
                break;
            case 2:
                Response.Redirect(@"~\AdminFiles\managerecipes.aspx", true);
                break;
            case 3:
                Response.Redirect(@"~\AdminFiles\managearticles.aspx", true);
                break;
            case 4:
                Response.Redirect(@"~\AdminFiles\managehomepage.aspx", true);
                break;
            default:
                throw new InvalidOperationException();
        }
    }
}