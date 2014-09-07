using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx";
        //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

        //Prevents opeining of page if user is already logged in
        if (User.Identity.IsAuthenticated && Request.QueryString["ReturnUrl"] != null)
        {
            Response.Redirect(@"~\generalerror.aspx?msg=403&amp;handler=customErrors%20section%20-%20Web.config");
        }

        var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        if (!String.IsNullOrEmpty(returnUrl))
        {
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        }
    }
}