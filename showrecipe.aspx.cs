using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showrecipe : System.Web.UI.Page
{
    protected string RecipeTitle;
    protected int PreparationTime;
    protected int Views;
    protected int Favorites;
    protected int Likes;
    protected string Category;
    protected DateTime DateAdded;
    protected int RecipeID;
    protected RecipeDB recipeDB;
    protected RecipeClass Recipe;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Recipe = recipeDB.GetRecipe(RecipeID);

        RecipeTitle = Recipe.RecipeName;
        PreparationTime = Recipe.PreparationTime;
        Views = Recipe.Views;
        Favorites = Recipe.Favorites;
        Likes = Recipe.Likes;
        DateAdded = Recipe.DateAdded;
        Category = Recipe.RecipeCategory;

        if (Membership.GetUser() != null)
        {
            if (recipeDB.isFav(RecipeID, Membership.GetUser().UserName))
            {
                Favorite_Button.ImageUrl = "~/Images/rem_fav.png";
            }
            else
            {
                Favorite_Button.ImageUrl = "~/Images/add_fav.png";
            }
        }

        if (Recipe.ImagePath != null)
        {
            RecipeImage.ImageUrl = Recipe.ImagePath;
        }

        if (!this.IsPostBack)
        {
            Page.Title = RecipeTitle;
            string[] newLineDelim = { Environment.NewLine };

            string[] _Ingredients = Recipe.Ingredients.Split(newLineDelim, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in _Ingredients)
            {
                IngredientsList.Items.Add(item);
            }

            string[] _Directions = Recipe.Directions.Split(newLineDelim, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in _Directions)
            {
                DirectionsList.Items.Add(item);
            }
        }

        this.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        recipeDB = new RecipeDB();
        RecipeID = int.Parse(Request.QueryString["RecipeID"]);

        if (!this.IsPostBack)
        {
            if (Request.UrlReferrer != null && !new RecipeDB().isCook(RecipeID, User.Identity.Name))
            {
                if (!(Request.UrlReferrer.Query.Contains(HttpContext.Current.Request.Url.PathAndQuery)
                    || Request.UrlReferrer.AbsoluteUri == Request.Url.AbsoluteUri))
                    recipeDB.IncreaseView(RecipeID);
            }
        }

        DataTable CommentsTable = new CommentsDB().GetComments(RecipeID);
        DataView CommentsView = new DataView(CommentsTable);

        if (CommentsTable.Rows.Count != 0)
        {
            CommentsView.Sort = "PostedTime DESC";
            CommentsRepeater.DataSource = CommentsView;
            CommentsRepeater.DataBind();
            CommentsRepeater.Visible = true;
            NoCommentsLabel.Visible = false;
        }
        else
        {
            NoCommentsLabel.Visible = true;
            CommentsRepeater.Visible = false;
        }

        if (Membership.GetUser() != null)
            CommentView.SetActiveView(LoggedUserView);
        else
            CommentView.SetActiveView(NoUserView);

        ClickHere.NavigateUrl = @"~\Account\Login.aspx?ReturnUrl=" + Page.Request.RawUrl;
    }

    protected void Favorite_Click(object sender, ImageClickEventArgs e)
    {
        if (Membership.GetUser() == null)
        {
            Response.Redirect(@"~\Account\Login.aspx?ReturnUrl=" + Page.Request.RawUrl, true);
        }

        if (Favorite_Button.ImageUrl == "~/Images/add_fav.png")
        {
            new RecipeDB().MakeFav(int.Parse(Request.QueryString["RecipeID"]), Membership.GetUser().UserName);
        }
        else
        {
            new RecipeDB().RemoveFav(int.Parse(Request.QueryString["RecipeID"]), Membership.GetUser().UserName);
        }
        Response.Redirect(Page.Request.Url.AbsoluteUri, false);
    }

    protected void CommentButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Membership.GetUser() == null)
                Response.Redirect(@"~\Account\Login.aspx?ReturnUrl=" + Page.Request.RawUrl, false);
            else
            {
                CommentsClass newComment = new CommentsClass();
                newComment.User = User.Identity.Name;
                newComment.RecipeID = RecipeID;
                newComment.Comment = CommentBox.Text;
                newComment.PostedTime = DateTime.Now;

                new CommentsDB().InsertComment(newComment);

                Response.Redirect(Page.Request.RawUrl);
            }
        }
    }
}