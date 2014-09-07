using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminFiles_managehomepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable RecipeTable = new RecipeDB().AllVerifiedRecipes();
        TopRecipeList.DataSource = RecipeTable;
        TopRecipeList.DataTextField = "RecipeName";
        TopRecipeList.DataValueField = "RecipeID";
        TopRecipeList.DataBind();
    }
    
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        new RecipeDB().setTopRecipe(int.Parse(TopRecipeList.SelectedValue));
    }
}