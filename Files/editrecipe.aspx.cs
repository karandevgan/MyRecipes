using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Files_editrecipe : System.Web.UI.Page
{
    protected string user;
    protected int RecipeID;
    protected string RecipeName;
    protected string Category;
    protected int PreparationTime;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        CategoryList.SelectedValue = Category;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RecipeID = int.Parse(Request.QueryString["ID"]);
        user = User.Identity.Name;

        RecipeClass Recipe = new RecipeDB().GetRecipe(RecipeID);

        if (Recipe.Cook != user)
            throw new InvalidOperationException();

        RecipeName = Recipe.RecipeName;
        Category = Recipe.RecipeCategory;
        PreparationTime = Recipe.PreparationTime;

        RecipeImage.ImageUrl = Recipe.ImagePath;

        if (!this.IsPostBack)
        {
            string[] newLineDelim = { Environment.NewLine };

            string[] _Ingredients = Recipe.Ingredients.Split(newLineDelim, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in _Ingredients)
            {
                IngredientsTxt.Text += item;
                IngredientsTxt.Text += Environment.NewLine;
            }

            string[] _Directions = Recipe.Directions.Split(newLineDelim, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in _Directions)
            {
                DirectionsTxt.Text += item;
                DirectionsTxt.Text += Environment.NewLine;
            }
        }
        this.DataBind();
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        if (this.Page.IsValid)
        {
            if (PhotoUpload.HasFile)
            {
                string FileName = Path.GetFileName(PhotoUpload.PostedFile.FileName);
                string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(PhotoUpload.PostedFile.FileName);
                string FileExtension = Path.GetExtension(PhotoUpload.PostedFile.FileName);

                string FolderPath = "~\\UserFiles\\" + User.Identity.Name.ToString();
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(Server.MapPath(FolderPath));

                string ImagePath = string.Concat(FolderPath, "\\", FileName);

                int i = 1;
                while (File.Exists(Server.MapPath(ImagePath)))
                {
                    ImagePath = string.Concat(FolderPath, "\\", FileNameWithoutExtension, i.ToString(), FileExtension);
                    i++;
                }

                PhotoUpload.SaveAs(Server.MapPath(ImagePath));
                new RecipeDB().ChangeImage(RecipeID, user, ImagePath);
            }

            new RecipeDB().UpdateRecipe(RecipeID, User.Identity.Name, CategoryList.SelectedItem.Value, IngredientsTxt.Text, DirectionsTxt.Text, PreparationTime);
            if (File.Exists(RecipeImage.ImageUrl) && RecipeImage.ImageUrl != @"~\Images\noimage.jpg")
                File.Delete(RecipeImage.ImageUrl);
            
            Response.Redirect(@"~\Files\myrecipes.aspx?Ch=sub", true);
        }
    }

    protected void PhotoUploadValidator_ServerValidate(object source, ServerValidateEventArgs e)
    {
        if (PhotoUpload.HasFile)
        {
            if (PhotoUpload.PostedFile.ContentType.ToLower() == "image/jpg" || PhotoUpload.PostedFile.ContentType.ToLower() == "image/gif" ||
                PhotoUpload.PostedFile.ContentType.ToLower() == "image/png" || PhotoUpload.PostedFile.ContentType.ToLower() == "image/jpeg")
            {
                int fileSize = PhotoUpload.PostedFile.ContentLength;
                if (fileSize <= (100 * 1024))
                    e.IsValid = true;
                else
                    e.IsValid = false;
            }
            else
                e.IsValid = false;
        }
    }
}