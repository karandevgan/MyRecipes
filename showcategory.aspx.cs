using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;

public partial class showcategory : System.Web.UI.Page
{
    protected string RecipeCategory;
    protected int TotalRecipes;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        CategoryViewList.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RecipeCategory = Request.QueryString["Category"];

        if (!Page.IsPostBack)
        {
            Sort.Items[0].Selected = true;
            Page.Title = RecipeCategory;
        }

        switch (RecipeCategory)
        {
            case "Chinese":
                GroupImage.ImageUrl = "~\\Images\\chinese_group_detail.png";
                break;
            case "French":
                GroupImage.ImageUrl = "~\\Images\\french_group_detail.png";
                break;
            case "German":
                GroupImage.ImageUrl = "~\\Images\\german_group_detail.png";
                break;
            case "Indian":
                GroupImage.ImageUrl = "~\\Images\\indian_group_detail.png";
                break;
            case "Italian":
                GroupImage.ImageUrl = "~\\Images\\italian_group_detail.png";
                break;
            case "Mexican":
                GroupImage.ImageUrl = "~\\Images\\mexican_group_detail.png";
                break;
            case "Spanish":
                GroupImage.ImageUrl = "~\\Images\\mexican_group_detail.png";
                break;
            case "Other":
                GroupImage.ImageUrl = "~\\Images\\french_group_detail.png";
                break;
            default:
                throw new InvalidOperationException();
        }

        DataTable ShowCategoryTable = (new RecipeDB()).GetRecipes(RecipeCategory);

        if (ShowCategoryTable.Rows.Count > 0)
        {
            DataView ListView = new DataView();
            ListView.Table = ShowCategoryTable;
            CategoryViewList.DataSource = ListView;
            TotalRecipes = ListView.Count;

            if (Sort.SelectedItem.Value == "Latest")
                ListView.Sort = "DateAdded DESC";
            else if (Sort.SelectedItem.Value == "Popular")
                ListView.Sort = "views DESC";
            else if (Sort.SelectedItem.Value == "Favorites")
                ListView.Sort = "favorites DESC";
            else if (Sort.SelectedItem.Value == "PrepTime")
                ListView.Sort = "PreparationTime ASC";

            DataPager.SetPageProperties(0, 4, false);

            this.DataBind();

            RecipeDiv.Visible = true;
            NoRecipeLbl.Visible = false;
        }
        else
        {
            RecipeDiv.Visible = false;
            NoRecipeLbl.Visible = true;
        }
    }
}