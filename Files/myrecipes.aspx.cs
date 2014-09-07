using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Files_myrecipes : System.Web.UI.Page
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

    protected string choice;

    protected DataTable Recipes = new DataTable();
    protected DataView RecipeView = new DataView();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["sortOrder"] = "";

            choice = Request.QueryString["Ch"];
            
            if (choice == "fav")
            {
                Page.Title = "My Favorite Recipes";
                bindRecipesGridView("RecipeName", "ASC");
            }
            else if (choice == "sub")
            {
                Page.Title = "My Recipes";
                bindSubmittedRecipeGridView("RecipeName", "ASC");
            }
            else
                throw new InvalidOperationException();
        }
        Page.DataBind();
    }

    protected void removeLink_Command(object sender, CommandEventArgs e)
    {
        string user = User.Identity.Name;
        new RecipeDB().RemoveFav(int.Parse(e.CommandArgument.ToString()), user);
        Response.Redirect(Request.RawUrl, false);
    }

    protected void deleteLink_Command(object sender, CommandEventArgs e)
    {
        char[] delim = { ',' };
        string[] arguments = e.CommandArgument.ToString().Split(delim);

        string user = User.Identity.Name;
        new RecipeDB().DeleteRecipe(int.Parse(arguments[0]), user);

        if (File.Exists(Server.MapPath(arguments[1])) && (arguments[1] != "~\\Images\\noimage.jpg"))
            File.Delete(Server.MapPath(arguments[1]));

        Response.Redirect(Request.RawUrl, false);
    }

    protected void editLink_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect(@"~\Files\editrecipe.aspx?ID=" + e.CommandArgument.ToString(), false);
    }

    public void bindSubmittedRecipeGridView(string sortExp, string sortDir)
    {
        Recipes = new RecipeDB().GetMyRecipes(User.Identity.Name);

        MyRecipesView.SetActiveView(SubmittedRecipesView);
        MultiView subView;
        subView = (MultiView)this.MyRecipesView.GetActiveView().FindControl("isRecipeSubmitted");

        if (Recipes.Rows.Count > 0)
        {
            RecipeView.Table = Recipes;
            RecipeView.Sort = string.Format("{0} {1}", sortExp, sortDir);
            subView.SetActiveView(RecipeSubmitted);

            SubmittedRecipesGrid.DataSource = RecipeView;
        }
        else
            subView.SetActiveView(NoRecipeSubmitted);

        SubmittedRecipesGrid.DataBind();
    }

    public void bindRecipesGridView(string sortExp, string sortDir)
    {
        Recipes = new RecipeDB().GetFavRecipes(User.Identity.Name);

        MyRecipesView.SetActiveView(favorites);
        MultiView favView;
        favView = (MultiView)this.MyRecipesView.GetActiveView().FindControl("isFavPresentView");

        if (Recipes.Rows.Count > 0)
        {
            RecipeView.Table = Recipes;
            RecipeView.Sort = string.Format("{0} {1}", sortExp, sortDir);
            favView.SetActiveView(FavPresent);

            RecipesGrid.DataSource = RecipeView;
        }
        else
            favView.SetActiveView(FavAbsent);

        RecipesGrid.DataBind();
    }

    protected void SubmittedRecipesGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        bindSubmittedRecipeGridView(e.SortExpression, sortOrder);
    }
   
    protected void RecipesGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        bindRecipesGridView(e.SortExpression, sortOrder);
    }
}
