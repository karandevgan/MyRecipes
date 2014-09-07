using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

/// <summary>
/// Summary description for CommentsDB
/// </summary>
public class CommentsDB
{
    private string ConnectionString;
    private SqlConnection DefaultConnection;
	
    public CommentsDB()
	{
		//
		// TODO: Add constructor logic here
		//
        ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DefaultConnection = new SqlConnection(ConnectionString);
	}

    public void InsertComment(CommentsClass comment)
    {
        SqlCommand InsertCommentCommand = new SqlCommand("InsertComment", DefaultConnection);
        InsertCommentCommand.CommandType = System.Data.CommandType.StoredProcedure;

        InsertCommentCommand.Parameters.Add("@RecipeID", SqlDbType.Int);
        InsertCommentCommand.Parameters["@RecipeID"].Value = comment.RecipeID;

        InsertCommentCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
        InsertCommentCommand.Parameters["@UserName"].Value = comment.User;

        InsertCommentCommand.Parameters.Add("@Comment", SqlDbType.Text);
        InsertCommentCommand.Parameters["@Comment"].Value = comment.Comment;

        InsertCommentCommand.Parameters.Add("@PostedTime", SqlDbType.DateTime);
        InsertCommentCommand.Parameters["@PostedTime"].Value = comment.PostedTime;

        try
        {
            DefaultConnection.Open();
            InsertCommentCommand.ExecuteNonQuery();
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

    public DataTable GetComments(int RecipeID)
    {
        string CommandString = "SELECT * FROM Comments WHERE RecipeID = @RecipeID";
        SqlCommand Command = new SqlCommand(CommandString, DefaultConnection);
        Command.Parameters.Add("@RecipeID", SqlDbType.Int);
        Command.Parameters["@RecipeID"].Value = RecipeID;

        SqlDataAdapter CommentsDA = new SqlDataAdapter(Command);
        DataSet CommentsDS = new DataSet();

        try
        {
            CommentsDA.Fill(CommentsDS, "Comments");
            return CommentsDS.Tables["Comments"];
        }
        catch (Exception e)
        {
            throw;
        }
    }
}