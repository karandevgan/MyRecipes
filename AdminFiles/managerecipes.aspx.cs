using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminFiles_managerecipes : System.Web.UI.Page
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

    protected DataTable Recipes = new DataTable();
    protected DataView RecipeView = new DataView();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["sortOrder"] = "";
            ViewState["sortExpression"] = "RecipeName";
            bindRecipesGridView("RecipeName", sortOrder);
        }
    }

    public void bindRecipesGridView(string sortExp, string sortDir)
    {
        Recipes = new RecipeDB().AllRecipes();

        RecipeView.Table = Recipes;
        RecipeView.Sort = string.Format("{0} {1}", sortExp, sortDir);
        RecipesGrid.DataSource = RecipeView;

        RecipesGrid.DataBind();
    }


    protected void RecipesGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortExpression"] = e.SortExpression;
        RecipesGrid.PageIndex = 0;
        bindRecipesGridView(e.SortExpression, sortOrder);
    }

    protected void deleteLink_Command(object sender, CommandEventArgs e)
    {
        char[] delim = { ',' };
        string[] arguments = e.CommandArgument.ToString().Split(delim);

        new RecipeDB().DeleteRecipeAdmin(int.Parse(arguments[0]));

        if (File.Exists(Server.MapPath(arguments[1])) && (arguments[1] != "~\\Images\\noimage.jpg"))
            File.Delete(Server.MapPath(arguments[1]));

        Response.Redirect(Request.RawUrl, false);
    }

    protected void RecipesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RecipesGrid.PageIndex = e.NewPageIndex;
        bindRecipesGridView(ViewState["sortExpression"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void verifyLink_Command(object sender, CommandEventArgs e)
    {
        char[] delim = { ',' };
        string[] arguments = e.CommandArgument.ToString().Split(delim);

        new RecipeDB().changeVerification(int.Parse(arguments[0]), bool.Parse(arguments[1]));

        Response.Redirect(Request.RawUrl, false);
    }
}