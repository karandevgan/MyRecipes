using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected int TopRecipeID;
    protected string TopRecipeName;
    protected string TopRecipeImage;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        AllRecipeList.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        TopRecipeID = new RecipeDB().getTopRecipe();
        if (TopRecipeID != 0)
        {
            TopRecipeDiv.Visible = true;
            RecipeClass TopRecipeClass = new RecipeDB().GetRecipe(TopRecipeID);
            TopRecipeName = TopRecipeClass.RecipeName;
            TopRecipeImage = TopRecipeClass.ImagePath;
        }
        else
            TopRecipeDiv.Visible = false;

        DataTable AllRecipesTable = (new RecipeDB()).GetLatestRecipes();

        if (AllRecipesTable.Rows.Count > 0)
        {
            DataView ListView = new DataView();
            ListView.Table = AllRecipesTable;
            AllRecipeList.DataSource = ListView;
        }

        DataTable LatestArticles = new ArticleDB().GetLatestArticles();
        ArticlesRepeater.DataSource = LatestArticles;

        this.DataBind();

    }
}