using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminFiles_manageusers : System.Web.UI.Page
{
    public string sortOrder
    {
        get
        {
            if (ViewState["sortOrder"].ToString() == "ASC")
            {
                ViewState["sortOrder"] = "DESC";
            }
            else
            {
                ViewState["sortOrder"] = "ASC";
            }

            return ViewState["sortOrder"].ToString();
        }

        set
        {
            ViewState["sortOrder"] = value;
        }
    }
    
    protected DataTable UserData = new DataTable();
    protected DataView UserDataView = new DataView();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["sortOrder"] = "";
            ViewState["sortExpression"] = "RecipeName";
            bindUserDataView("UserName", sortOrder);            
        }
    }

    protected void UserDataGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortExpression"] = e.SortExpression;
        UserDataGrid.PageIndex = 0;
        bindUserDataView(e.SortExpression, sortOrder);
    }

    protected void bindUserDataView(string sortExp, string sortOrder)
    {
        UserData = new UserDetailsDB().GetUsers();

        UserDataView.Table = UserData;
        UserDataView.Sort = string.Format("{0} {1}", sortExp, sortOrder);
        UserDataGrid.DataSource = UserDataView;

        UserDataGrid.DataBind();
    }

    protected void blockuser_Command(object sender, CommandEventArgs e)
    {
        if (Membership.GetUser().UserName == e.CommandArgument.ToString() || e.CommandArgument.ToString() == "admin")
        {

        }
        else
        {
            MembershipUser user = Membership.GetUser(e.CommandArgument.ToString());
            if (user != null)
                if (user.IsApproved)
                    user.IsApproved = false;
                else
                    user.IsApproved = true;

            Membership.UpdateUser(user);
        }

        Response.Redirect(Request.RawUrl, false);
    }

    protected void makeadmin_Command(object sender, CommandEventArgs e)
    {
        if (Membership.GetUser().UserName == e.CommandArgument.ToString() || e.CommandArgument.ToString() == "admin")
        {

        }
        else
        {
            if (Roles.GetRolesForUser(e.CommandArgument.ToString()).Contains("Admin"))
                Roles.RemoveUserFromRole(e.CommandArgument.ToString(), "Admin");
            else
                Roles.AddUserToRole(e.CommandArgument.ToString(), "Admin");
        }
        Response.Redirect(Request.RawUrl, false);
    }
    
    protected void UserDataGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UserDataGrid.PageIndex = e.NewPageIndex;
        bindUserDataView(ViewState["sortExpression"].ToString(), ViewState["sortOrder"].ToString());
    }
}