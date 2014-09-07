using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminFiles_managearticles : System.Web.UI.Page
{
    public string sortOrder
    {
        get
        {
            if (ViewState["sortOrder"].ToString() == "DESC")
            {
                ViewState["sortOrder"] = "ASC";
            }
            else
            {
                ViewState["sortOrder"] = "DESC";
            }

            return ViewState["sortOrder"].ToString();
        }

        set
        {
            ViewState["sortOrder"] = value;
        }
    }

    protected DataTable Articles = new DataTable();
    protected DataView ArticleView = new DataView();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["sortOrder"] = "";
            ViewState["sortExpression"] = "PostedTime";
            bindArticlesGridView("PostedTime", sortOrder);
        }
    }

    private void bindArticlesGridView(string sortExp, string sortDir)
    {
        Articles = new ArticleDB().GetAllArticles();

        ArticleView.Table = Articles;
        ArticleView.Sort = string.Format("{0} {1}", sortExp, sortDir);
        ArticlesGrid.DataSource = ArticleView;

        ArticlesGrid.DataBind();
    }

    protected void ArticlesGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortExpression"] = e.SortExpression;
        ArticlesGrid.PageIndex = 0;
        bindArticlesGridView(e.SortExpression, sortOrder);
    }

    protected void ArticlesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ArticlesGrid.PageIndex = e.NewPageIndex;
        bindArticlesGridView(ViewState["sortExpression"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void deleteLink_Command(object sender, CommandEventArgs e)
    {
        if (Roles.IsUserInRole(Membership.GetUser().UserName, "Admin"))
        {
            char[] delim = { ',' };
            string[] arguments = e.CommandArgument.ToString().Split(delim);

            new ArticleDB().DeleteArticle(int.Parse(arguments[0]), arguments[1]);
            Response.Redirect(Request.RawUrl, false);
        }
        else
            throw new InvalidOperationException();
    }

    protected void verifyLink_Command(object sender, CommandEventArgs e)
    {
        char[] delim = { ',' };
        string[] arguments = e.CommandArgument.ToString().Split(delim);

        new ArticleDB().changeVerification(int.Parse(arguments[0]), bool.Parse(arguments[1]));

        Response.Redirect(Request.RawUrl, false);
    }
}