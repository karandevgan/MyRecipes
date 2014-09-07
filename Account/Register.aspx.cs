using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        if (this.Page.IsValid)
        {
            RegisterUser.UserName = RegisterUser.UserName.ToLower();
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }
    }

    protected void user_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        RegisterUser.UserName = RegisterUser.UserName.ToLower();
        if (Membership.GetUser(RegisterUser.UserName) != null)
        {
            e.IsValid = false;
        }
    }

    protected void email_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        RegisterUser.Email = RegisterUser.Email.ToLower();
        if (Membership.GetUserNameByEmail(RegisterUser.Email) != null)
        {
            e.IsValid = false;  
        }
    }
}