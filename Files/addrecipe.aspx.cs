using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addrecipe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void UploadRecipe_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            RecipeClass recipeObject;
            RecipeDB recipeDatabase = new RecipeDB();
            
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
                while(File.Exists(Server.MapPath(ImagePath)))
                {
                    ImagePath = string.Concat(FolderPath, "\\", FileNameWithoutExtension,i.ToString(),FileExtension);
                    i++;
                }

                PhotoUpload.SaveAs(Server.MapPath(ImagePath));

                recipeObject = new RecipeClass(RecipeCategory.SelectedItem.Value, RecipeName.Text,
                    User.Identity.Name, Ingredients.Text, Directions.Text, int.Parse(PreparationTime.Text), ImagePath);
            }
            else
            {
                string ImagePath = "~\\Images\\noimage.jpg";
                recipeObject = new RecipeClass(RecipeCategory.SelectedItem.Value, RecipeName.Text,
                    User.Identity.Name, Ingredients.Text, Directions.Text, int.Parse(PreparationTime.Text), ImagePath);
            }
            recipeDatabase.InsertRecipe(recipeObject);

            Response.Redirect("~\\Default.aspx");
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
    protected void RecipeCategoryValidator_ServerValidate(object source, ServerValidateEventArgs e)
    {
        if (RecipeCategory.SelectedItem.Value == "Empty")
        {
            e.IsValid = false;
        }
    }
}