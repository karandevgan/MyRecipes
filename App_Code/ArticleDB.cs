using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Contains function to access Article relation in Database
/// </summary>

public class ArticleDB
{
    private string ConnectionString;
    private SqlConnection DefaultConnection;

    public ArticleDB()
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DefaultConnection = new SqlConnection(ConnectionString);
    }

    public void UploadArticle(ArticleClass article)
    {
        SqlCommand UploadArticleCommand = new SqlCommand("UploadArticle", DefaultConnection);
        UploadArticleCommand.CommandType = System.Data.CommandType.StoredProcedure;

        UploadArticleCommand.Parameters.Add("@Author", SqlDbType.NVarChar, 50);
        UploadArticleCommand.Parameters.Add("@Title", SqlDbType.NVarChar);
        UploadArticleCommand.Parameters.Add("@Content", SqlDbType.Text);
        UploadArticleCommand.Parameters.Add("@Time", SqlDbType.DateTime);

        UploadArticleCommand.Parameters["@Author"].Value = article.ArticleAuthor;
        UploadArticleCommand.Parameters["@Title"].Value = article.ArticleTitle;
        UploadArticleCommand.Parameters["@Content"].Value = article.ArticleContent;
        UploadArticleCommand.Parameters["@Time"].Value = article.PostedTime;

        try
        {
            DefaultConnection.Open();
            UploadArticleCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public ArticleClass ViewArticle(int articleID)
    {
        SqlCommand ViewArticleCommand;

        if (Membership.GetUser() != null)
        {
            if (Roles.IsUserInRole(Membership.GetUser().UserName, "Admin") || isAuthor(articleID, Membership.GetUser().UserName))
                ViewArticleCommand = new SqlCommand("ViewArticleAdmin", DefaultConnection);
            else
                ViewArticleCommand = new SqlCommand("ViewArticle", DefaultConnection);
        }
        else
            ViewArticleCommand = new SqlCommand("ViewArticle", DefaultConnection);

        ViewArticleCommand.CommandType = System.Data.CommandType.StoredProcedure;

        ViewArticleCommand.Parameters.Add("@articleID", SqlDbType.Int);
        ViewArticleCommand.Parameters["@articleID"].Value = articleID;

        try
        {
            DefaultConnection.Open();
            SqlDataReader ViewArticleReader = ViewArticleCommand.ExecuteReader(CommandBehavior.SingleRow);
            ViewArticleReader.Read();

            ArticleClass Readarticle = new ArticleClass();
            Readarticle.ArticleID = articleID;
            Readarticle.ArticleTitle = ViewArticleReader["ArticleTitle"].ToString();
            Readarticle.ArticleAuthor = ViewArticleReader["ArticleAuthor"].ToString();
            Readarticle.ArticleContent = ViewArticleReader["ArticleContent"].ToString();
            Readarticle.PostedTime = (DateTime)ViewArticleReader["PostedTime"];

            ViewArticleReader.Close();
            return Readarticle;
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            DefaultConnection.Close();
        }
    }

    public void IncreaseView(int articleID)
    {
        string ViewCommandText = "UPDATE Articles SET ArticleViews = ArticleViews + 1 WHERE ArticleID = @articleID";

        SqlCommand viewCommand = new SqlCommand(ViewCommandText, DefaultConnection);
        viewCommand.Parameters.Add("@articleID", SqlDbType.Int);
        viewCommand.Parameters["@articleID"].Value = articleID;

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

    public DataTable GetAllArticles()
    {
        SqlCommand AllArticlesCommand;

        if (Membership.GetUser() != null && Roles.IsUserInRole(Membership.GetUser().UserName, "Admin"))
            AllArticlesCommand = new SqlCommand("GetAllArticlesAdmin", DefaultConnection);
        else
            AllArticlesCommand = new SqlCommand("GetAllArticles", DefaultConnection);

        AllArticlesCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter AllArticlesDA = new SqlDataAdapter(AllArticlesCommand);
        DataSet AllArticlesDS = new DataSet();

        try
        {
            AllArticlesDA.Fill(AllArticlesDS, "ArticlesData");
            return AllArticlesDS.Tables["ArticlesData"];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteArticle(int articleID, string UserName)
    {
        SqlCommand DeleteArticleCommand = new SqlCommand("DeleteArticle", DefaultConnection);
        DeleteArticleCommand.CommandType = CommandType.StoredProcedure;

        DeleteArticleCommand.Parameters.Add("@articleID", SqlDbType.Int);
        DeleteArticleCommand.Parameters["@articleID"].Value = articleID;
        DeleteArticleCommand.Parameters.Add("@user", SqlDbType.NVarChar, 50);
        DeleteArticleCommand.Parameters["@user"].Value = UserName;

        try
        {
            DefaultConnection.Open();
            DeleteArticleCommand.ExecuteNonQuery();
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

    public void changeVerification(int articleID, bool isVerified)
    {

        if (Membership.GetUser() != null && Roles.IsUserInRole(Membership.GetUser().UserName, "Admin"))
        {
            string changeVerificationString = "";
            if (isVerified == false)
                changeVerificationString = "UPDATE Articles SET Verified = 1 WHERE ArticleID = @articleID";
            else
                changeVerificationString = "UPDATE ArticleData SET Verified = 0 WHERE ArticleID = @articleID";

            SqlCommand changeVerificationCommand = new SqlCommand(changeVerificationString, DefaultConnection);
            changeVerificationCommand.Parameters.Add("@articleID", SqlDbType.Int);
            changeVerificationCommand.Parameters["@articleID"].Value = articleID;

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

    public bool isAuthor(int articleID, string username)
    {
        string isAuthorString = "SELECT ArticleAuthor FROM Articles WHERE ArticleAuthor = @ArticleAuthor AND ArticleID = @articleID";
        SqlCommand isAuthorCommand = new SqlCommand(isAuthorString, DefaultConnection);
        isAuthorCommand.Parameters.Add("@ArticleAuthor", SqlDbType.NVarChar, 50);
        isAuthorCommand.Parameters["@ArticleAuthor"].Value = username;

        isAuthorCommand.Parameters.Add("@ArticleID", SqlDbType.Int);
        isAuthorCommand.Parameters["@ArticleID"].Value = articleID;

        try
        {
            DefaultConnection.Open();
            SqlDataReader isAuhtorReader = isAuthorCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (isAuhtorReader.HasRows)
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

    public DataTable GetLatestArticles()
    {
        SqlCommand GetLatestArticlesCommand = new SqlCommand("GetLatestArticles", DefaultConnection);
        GetLatestArticlesCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter GetLatestArticlesDA = new SqlDataAdapter(GetLatestArticlesCommand);
        DataSet GetLatestArticlesDS = new DataSet();

        try
        {
            GetLatestArticlesDA.Fill(GetLatestArticlesDS, "GetLatestRecipes");
            return GetLatestArticlesDS.Tables["GetLatestRecipes"];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable GetAllVerifiedArticles()
    {
        SqlCommand AllVerifiedArticlesCommand;

        AllVerifiedArticlesCommand = new SqlCommand("GetAllArticles", DefaultConnection);

        AllVerifiedArticlesCommand.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter AllVerifiedArticlesDA = new SqlDataAdapter(AllVerifiedArticlesCommand);
        DataSet AllVerifiedArticlesDS = new DataSet();

        try
        {
            AllVerifiedArticlesDA.Fill(AllVerifiedArticlesDS, "ArticlesData");
            return AllVerifiedArticlesDS.Tables["ArticlesData"];
        }
        catch (Exception)
        {
            throw;
        }
    }
}