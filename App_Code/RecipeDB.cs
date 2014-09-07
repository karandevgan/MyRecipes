using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Web.Providers.Entities;

/// <summary>
/// Summary description for RecipeDB
/// </summary>
public class RecipeDB
{
    private string ConnectionString;
    private SqlConnection DefaultConnection;

    public RecipeDB()
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DefaultConnection = new SqlConnection(ConnectionString);
    }

    public void InsertRecipe(RecipeClass recipe)
    {
        SqlCommand InsertRecipeCommand = new SqlCommand("InsertRecipe", DefaultConnection);

        InsertRecipeCommand.CommandType = CommandType.StoredProcedure;

        InsertRecipeCommand.Parameters.Add("@RecipeCategory", SqlDbType.NVarChar, 50);
        InsertRecipeCommand.Parameters["@RecipeCategory"].Value = recipe.RecipeCategory;

        InsertRecipeCommand.Parameters.Add("@RecipeName", SqlDbType.NVarChar, 50);
        InsertRecipeCommand.Parameters["@RecipeName"].Value = recipe.RecipeName;

        InsertRecipeCommand.Parameters.Add("@Cook", SqlDbType.NVarChar, 50);
        InsertRecipeCommand.Parameters["@Cook"].Value = recipe.Cook;


        InsertRecipeCommand.Parameters.Add("@ImagePath", SqlDbType.NVarChar, recipe.ImagePath.Length);
        InsertRecipeCommand.Parameters["@ImagePath"].Value = recipe.ImagePath;

        InsertRecipeCommand.Parameters.Add("@Ingredients", SqlDbType.Text);
        InsertRecipeCommand.Parameters["@Ingredients"].Value = recipe.Ingredients;

        InsertRecipeCommand.Parameters.Add("@Directions", SqlDbType.Text);
        InsertRecipeCommand.Parameters["@Directions"].Value = recipe.Directions;

        InsertRecipeCommand.Parameters.Add("@PreparationTime", SqlDbType.Int);
        InsertRecipeCommand.Parameters["@PreparationTime"].Value = recipe.PreparationTime;

        InsertRecipeCommand.Parameters.Add("@DateAdded", SqlDbType.Date);
        InsertRecipeCommand.Parameters["@DateAdded"].Value = recipe.DateAdded;

        try
        {
            DefaultConnection.Open();
            InsertRecipeCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public RecipeClass GetRecipe(int RecipeID)
    {
        SqlCommand GetRecipeCommand;
        if (Membership.GetUser() != null)
        {
            if (Roles.IsUserInRole(Membership.GetUser().UserName, "Admin") || isCook(RecipeID, Membership.GetUser().UserName))
                GetRecipeCommand = new SqlCommand("GetRecipeAdmin", DefaultConnection);
            else
                GetRecipeCommand = new SqlCommand("GetRecipe", DefaultConnection);
        }
        else
            GetRecipeCommand = new SqlCommand("GetRecipe", DefaultConnection);

        GetRecipeCommand.CommandType = CommandType.StoredProcedure;

        GetRecipeCommand.Parameters.Add(new SqlParameter("@RecipeID", SqlDbType.Int));
        GetRecipeCommand.Parameters["@RecipeID"].Value = RecipeID;

        try
        {
            DefaultConnection.Open();

            SqlDataReader RecipeReader = GetRecipeCommand.ExecuteReader(CommandBehavior.SingleRow);
            RecipeReader.Read();

            RecipeClass recipe = new RecipeClass();

            recipe.RecipeCategory = RecipeReader["RecipeCategory"].ToString();
            recipe.RecipeName = RecipeReader["RecipeName"].ToString();
            recipe.Cook = RecipeReader["Cook"].ToString();
            recipe.Directions = RecipeReader["Directions"].ToString();
            recipe.Ingredients = RecipeReader["Ingredients"].ToString();
            recipe.Views = (int)RecipeReader["views"];
            recipe.Favorites = (int)RecipeReader["favorites"];
            recipe.Likes = (int)RecipeReader["likes"];
            recipe.PreparationTime = (int)RecipeReader["PreparationTime"];
            recipe.ImagePath = RecipeReader["ImagePath"].ToString();
            recipe.DateAdded = (DateTime)RecipeReader["DateAdded"];

            RecipeReader.Close();
            return recipe;
        }
        catch (SqlException err)
        {
            throw new ApplicationException(err.Message);
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public DataTable AllRecipes()
    {
        SqlCommand AllRecipesCommand;
        if (Membership.GetUser() != null && Roles.IsUserInRole(Membership.GetUser().UserName, "Admin"))
            AllRecipesCommand = new SqlCommand("GetAllRecipesAdmin", DefaultConnection);
        else
            AllRecipesCommand = new SqlCommand("GetAllRecipes", DefaultConnection);

        AllRecipesCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter AllRecipesDA = new SqlDataAdapter(AllRecipesCommand);
        DataSet AllRecipesDS = new DataSet();

        try
        {
            AllRecipesDA.Fill(AllRecipesDS, "RecipeData");
            return AllRecipesDS.Tables["RecipeData"];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetRecipes(string GroupName)
    {
        SqlCommand GetRecipesCommand = new SqlCommand("GetRecipes", DefaultConnection);
        GetRecipesCommand.CommandType = CommandType.StoredProcedure;

        GetRecipesCommand.Parameters.Add(new SqlParameter("@RecipeCategory", SqlDbType.NVarChar, 50));
        GetRecipesCommand.Parameters["@RecipeCategory"].Value = GroupName;

        SqlDataAdapter GetRecipesDA = new SqlDataAdapter(GetRecipesCommand);
        DataSet GetRecipesDS = new DataSet();

        try
        {
            GetRecipesDA.Fill(GetRecipesDS, "RecipeData");
            return GetRecipesDS.Tables["RecipeData"];
        }
        catch
        {
            throw new ApplicationException();
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public DataTable GetFavRecipes(string user)
    {
        SqlCommand GetFavRecipesCommand = new SqlCommand("GetFavRecipes", DefaultConnection);
        GetFavRecipesCommand.CommandType = CommandType.StoredProcedure;

        GetFavRecipesCommand.Parameters.Add("@user", SqlDbType.NVarChar, 50);
        GetFavRecipesCommand.Parameters["@user"].Value = user;

        SqlDataAdapter FavRecipesDA = new SqlDataAdapter(GetFavRecipesCommand);
        DataSet FavRecipesDS = new DataSet();

        try
        {
            FavRecipesDA.Fill(FavRecipesDS, "RecipeData");
            return FavRecipesDS.Tables["RecipeData"];
        }
        catch (Exception)
        {

            throw;
        }
    }

    public DataTable GetMyRecipes(string user)
    {
        SqlCommand GetMyRecipesCommand = new SqlCommand("GetMyRecipes", DefaultConnection);
        GetMyRecipesCommand.CommandType = CommandType.StoredProcedure;

        GetMyRecipesCommand.Parameters.Add("@user", SqlDbType.NVarChar, 50);
        GetMyRecipesCommand.Parameters["@user"].Value = user;

        SqlDataAdapter MyRecipesDA = new SqlDataAdapter(GetMyRecipesCommand);
        DataSet MyRecipesDS = new DataSet();

        try
        {
            MyRecipesDA.Fill(MyRecipesDS, "RecipeData");
            return MyRecipesDS.Tables["RecipeData"];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void IncreaseView(int recipeID)
    {
        string ViewCommandText = "UPDATE RecipeData SET views = views + 1 WHERE RecipeID = @recipeID";

        SqlCommand viewCommand = new SqlCommand(ViewCommandText, DefaultConnection);
        viewCommand.Parameters.Add("@recipeID", SqlDbType.Int);
        viewCommand.Parameters["@recipeID"].Value = recipeID;

        try
        {
            DefaultConnection.Open();
            viewCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void MakeFav(int recipeID, string UserName)
    {
        SqlCommand MakeFavCommand = new SqlCommand("MakeFav", DefaultConnection);
        MakeFavCommand.CommandType = CommandType.StoredProcedure;

        MakeFavCommand.Parameters.Add("@RecipeID", SqlDbType.Int);
        MakeFavCommand.Parameters["@RecipeID"].Value = recipeID;
        MakeFavCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
        MakeFavCommand.Parameters["@UserName"].Value = UserName;


        try
        {
            DefaultConnection.Open();
            MakeFavCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw new ApplicationException();
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void RemoveFav(int recipeID, string UserName)
    {
        SqlCommand RemoveFavCommand = new SqlCommand("RemoveFav", DefaultConnection);
        RemoveFavCommand.CommandType = CommandType.StoredProcedure;

        RemoveFavCommand.Parameters.Add("@RecipeID", SqlDbType.Int);
        RemoveFavCommand.Parameters["@RecipeID"].Value = recipeID;
        RemoveFavCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
        RemoveFavCommand.Parameters["@UserName"].Value = UserName;

        try
        {
            DefaultConnection.Open();
            RemoveFavCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw new ApplicationException();
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void DeleteRecipe(int recipeID, string UserName)
    {
        SqlCommand DeleteRecipeCommand = new SqlCommand("DeleteRecipe", DefaultConnection);
        DeleteRecipeCommand.CommandType = CommandType.StoredProcedure;

        DeleteRecipeCommand.Parameters.Add("@recipeID", SqlDbType.Int);
        DeleteRecipeCommand.Parameters["@recipeID"].Value = recipeID;
        DeleteRecipeCommand.Parameters.Add("@user", SqlDbType.NVarChar, 50);
        DeleteRecipeCommand.Parameters["@user"].Value = UserName;

        try
        {
            DefaultConnection.Open();
            DeleteRecipeCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void DeleteRecipeAdmin(int recipeID)
    {
        SqlCommand DeleteRecipeCommand = new SqlCommand("DeleteRecipeAdmin", DefaultConnection);
        DeleteRecipeCommand.CommandType = CommandType.StoredProcedure;

        DeleteRecipeCommand.Parameters.Add("@recipeID", SqlDbType.Int);
        DeleteRecipeCommand.Parameters["@recipeID"].Value = recipeID;

        try
        {
            DefaultConnection.Open();
            DeleteRecipeCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void UpdateRecipe(int recipeID, string UserName, string recipeCategory, string Ingredients, string Directions, int PreparationTime)
    {
        SqlCommand UpdateRecipeCommand = new SqlCommand("UpdateRecipe", DefaultConnection);
        UpdateRecipeCommand.CommandType = CommandType.StoredProcedure;

        UpdateRecipeCommand.Parameters.Add("@recipeID", SqlDbType.Int);
        UpdateRecipeCommand.Parameters["@recipeID"].Value = recipeID;

        UpdateRecipeCommand.Parameters.Add("@recipeCategory", SqlDbType.NVarChar, 50);
        UpdateRecipeCommand.Parameters["@recipeCategory"].Value = recipeCategory;

        UpdateRecipeCommand.Parameters.Add("@user", SqlDbType.NVarChar, 50);
        UpdateRecipeCommand.Parameters["@user"].Value = UserName;

        UpdateRecipeCommand.Parameters.Add("@Ingredients", SqlDbType.Text);
        UpdateRecipeCommand.Parameters["@Ingredients"].Value = Ingredients;

        UpdateRecipeCommand.Parameters.Add("@Directions", SqlDbType.Text);
        UpdateRecipeCommand.Parameters["@Directions"].Value = Directions;

        UpdateRecipeCommand.Parameters.Add("@PreparationTime", SqlDbType.Int);
        UpdateRecipeCommand.Parameters["@PreparationTime"].Value = PreparationTime;

        UpdateRecipeCommand.Parameters.Add("@DateAdded", SqlDbType.Date);
        UpdateRecipeCommand.Parameters["@DateAdded"].Value = DateTime.Now.Date;

        try
        {
            DefaultConnection.Open();
            UpdateRecipeCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void ChangeImage(int recipeID, string user, string imagePath)
    {
        SqlCommand ChangeImageCommand = new SqlCommand("ChangeImage", DefaultConnection);
        ChangeImageCommand.CommandType = CommandType.StoredProcedure;

        ChangeImageCommand.Parameters.Add("@user", SqlDbType.NVarChar, 50);
        ChangeImageCommand.Parameters.Add("@recipeID", SqlDbType.Int);
        ChangeImageCommand.Parameters.Add("@imagePath", SqlDbType.NVarChar);

        ChangeImageCommand.Parameters["@user"].Value = user;
        ChangeImageCommand.Parameters["@recipeID"].Value = recipeID;
        ChangeImageCommand.Parameters["@imagePath"].Value = imagePath;

        try
        {
            DefaultConnection.Open();
            ChangeImageCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }

    }

    public bool isFav(int recipeID, string UserName)
    {
        string isFavString = "SELECT * FROM FavoriteRecipes WHERE RecipeID = @recipeID AND FavoriteUser = @UserName";
        SqlCommand isFavCommand = new SqlCommand(isFavString, DefaultConnection);
        isFavCommand.Parameters.Add("@recipeID", SqlDbType.Int);
        isFavCommand.Parameters["@recipeID"].Value = recipeID;

        isFavCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
        isFavCommand.Parameters["@UserName"].Value = UserName;

        try
        {
            DefaultConnection.Open();
            SqlDataReader isFavReader = isFavCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (isFavReader.HasRows)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public bool isCook(int recipeID, string UserName)
    {
        string isCookString = "SELECT Cook FROM RecipeData WHERE Cook = @Cook AND RecipeID = @recipeID";
        SqlCommand isCookCommand = new SqlCommand(isCookString, DefaultConnection);
        isCookCommand.Parameters.Add("@Cook", SqlDbType.NVarChar, 50);
        isCookCommand.Parameters["@Cook"].Value = UserName;

        isCookCommand.Parameters.Add("@RecipeID", SqlDbType.Int);
        isCookCommand.Parameters["@RecipeID"].Value = recipeID;

        try
        {
            DefaultConnection.Open();
            SqlDataReader isCookReader = isCookCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (isCookReader.HasRows)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void changeVerification(int recipeID, bool isVerified)
    {

        if (Membership.GetUser() != null && Roles.IsUserInRole(Membership.GetUser().UserName, "Admin"))
        {
            string changeVerificationString = "";
            if (isVerified == false)
                changeVerificationString = "UPDATE RecipeData SET Verified = 1 WHERE RecipeID = @recipeID";
            else
                changeVerificationString = "UPDATE RecipeData SET Verified = 0 WHERE RecipeID = @recipeID";

            SqlCommand changeVerificationCommand = new SqlCommand(changeVerificationString, DefaultConnection);
            changeVerificationCommand.Parameters.Add("@recipeID", SqlDbType.Int);
            changeVerificationCommand.Parameters["@recipeID"].Value = recipeID;

            try
            {
                DefaultConnection.Open();
                changeVerificationCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DefaultConnection.Close();
            }
        }
        else
            throw new InvalidOperationException();
    }

    public DataTable GetLatestRecipes()
    {
        SqlCommand GetLatestRecipesCommand = new SqlCommand("GetLatestRecipes", DefaultConnection);
        GetLatestRecipesCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter GetLatestRecipesDA = new SqlDataAdapter(GetLatestRecipesCommand);
        DataSet GetLatestRecipesDS = new DataSet();

        try
        {
            GetLatestRecipesDA.Fill(GetLatestRecipesDS, "GetLatestRecipes");
            return GetLatestRecipesDS.Tables["GetLatestRecipes"];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable AllVerifiedRecipes()
    {
        SqlCommand AllVerifiedRecipesCommand;

        AllVerifiedRecipesCommand = new SqlCommand("GetAllRecipes", DefaultConnection);

        AllVerifiedRecipesCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter AllVerifiedRecipesDA = new SqlDataAdapter(AllVerifiedRecipesCommand);
        DataSet AllVerifiedRecipesDS = new DataSet();

        try
        {
            AllVerifiedRecipesDA.Fill(AllVerifiedRecipesDS, "RecipeData");
            return AllVerifiedRecipesDS.Tables["RecipeData"];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void setTopRecipe(int RecipeID)
    {
        SqlCommand setTopRecipeCommand = new SqlCommand("setTopRecipe", DefaultConnection);
        setTopRecipeCommand.CommandType = CommandType.StoredProcedure;

        setTopRecipeCommand.Parameters.Add("recipeID", SqlDbType.Int);
        setTopRecipeCommand.Parameters["recipeID"].Value = RecipeID;

        try
        {
            DefaultConnection.Open();
            setTopRecipeCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public int getTopRecipe()
    {
        SqlCommand getTopRecipeCommand = new SqlCommand("getTopRecipe", DefaultConnection);
        getTopRecipeCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            DefaultConnection.Open();
            SqlDataReader getTopRecipeReader = getTopRecipeCommand.ExecuteReader(CommandBehavior.SingleRow);
            getTopRecipeReader.Read();

            if (getTopRecipeReader.HasRows)
            {
                return int.Parse(getTopRecipeReader[0].ToString());
            }
            else
                return 0;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }
}
