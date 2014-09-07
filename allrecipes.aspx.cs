using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class allrecipes : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        AllRecipeList.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {  
            Sort.Items[0].Selected = true;
        }

        DataTable AllRecipesTable = (new RecipeDB()).AllVerifiedRecipes();

        if (AllRecipesTable.Rows.Count > 0)
        {
            DataView ListView = new DataView();
            ListView.Table = AllRecipesTable;

            if (Sort.SelectedItem.Value == "Latest")
                ListView.Sort = "DateAdded DESC";
            else if (Sort.SelectedItem.Value == "Popular")
                ListView.Sort = "views DESC";
            else if (Sort.SelectedItem.Value == "Favorites")
                ListView.Sort = "favorites DESC";
            else if (Sort.SelectedItem.Value == "PrepTime")
                ListView.Sort = "PreparationTime ASC";

            DataPager.SetPageProperties(0, 8, false);
            AllRecipeList.DataSource = ListView;
            NoRecipeLbl.Visible = false;
            RecipesDiv.Visible = true;
        }
        else
        {
            NoRecipeLbl.Visible = true;
            RecipesDiv.Visible = false;
        }
    }
}