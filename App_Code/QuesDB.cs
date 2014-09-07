using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;

/// <summary>
/// Summary description for QuesDB
/// </summary>
public class QuesDB
{
    private string ConnectionString;
    private SqlConnection DefaultConnection;

	public QuesDB()
	{
        ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DefaultConnection = new SqlConnection(ConnectionString);
	}

    public void InsertQuestion(QuesClass ques)
    {
        SqlCommand InsertCommand = new SqlCommand("AddQuestion", DefaultConnection);
        InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

        InsertCommand.Parameters.Add("@Question", System.Data.SqlDbType.Text);
        InsertCommand.Parameters["@Question"].Value = ques.Question;

        InsertCommand.Parameters.Add("@Author", System.Data.SqlDbType.NVarChar, 50);
        InsertCommand.Parameters["@Author"].Value = ques.Author;

        InsertCommand.Parameters.Add("@PostedTime", System.Data.SqlDbType.DateTime);
        InsertCommand.Parameters["@PostedTime"].Value = ques.PostedTime;
        try
        {
            DefaultConnection.Open();
            InsertCommand.ExecuteNonQuery();
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

    public QuesClass GetQuestion(int questionID)
    {
        SqlCommand GetQuestionCommand = new SqlCommand("GetQuestion", DefaultConnection);
        GetQuestionCommand.CommandType = CommandType.StoredProcedure;

        GetQuestionCommand.Parameters.Add("@QuestionID", SqlDbType.Int);
        GetQuestionCommand.Parameters["@QuestionID"].Value = questionID;

        try
        {
            DefaultConnection.Open();
            SqlDataReader questionReader = GetQuestionCommand.ExecuteReader(CommandBehavior.SingleRow);
            questionReader.Read();

            QuesClass ques = new QuesClass();
            ques.QuestionID = questionID;
            ques.Question = questionReader["Question"].ToString();
            ques.Author = questionReader["Author"].ToString();
            ques.PostedTime = (DateTime)questionReader["PostedTime"];
            ques.Views = (int)questionReader["Views"];

            questionReader.Close();
            return ques;
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

    public DataTable GetAllQuestions()
    {
        string CommandString = "SELECT * FROM Questions";
        SqlCommand Command = new SqlCommand(CommandString, DefaultConnection);

        SqlDataAdapter AllQuestionsDA = new SqlDataAdapter(Command);
        DataSet AllQuestionsDS = new DataSet();

        try
        {
            AllQuestionsDA.Fill(AllQuestionsDS, "Questions");
            return AllQuestionsDS.Tables["Questions"];
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public DataTable GetMyQuestions(string user)
    {
        string CommandString = "SELECT * FROM Questions WHERE Author = @author";
        SqlCommand Command = new SqlCommand(CommandString, DefaultConnection);
        Command.Parameters.Add("@author", SqlDbType.NVarChar, 50);
        Command.Parameters["@author"].Value = user;

        SqlDataAdapter GetMyQuestionsDA = new SqlDataAdapter(Command);
        DataSet GetMyQuestionsDS = new DataSet();

        try
        {
            GetMyQuestionsDA.Fill(GetMyQuestionsDS, "Questions");
            return GetMyQuestionsDS.Tables["Questions"];
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public void increaseView(int QuestionID)
    {
        string CommandString = "UPDATE Questions SET Views = Views + 1 WHERE QuestionID = @QuestionID";

        SqlCommand Command = new SqlCommand(CommandString, DefaultConnection);
        Command.Parameters.Add("@QuestionID", SqlDbType.Int);
        Command.Parameters["@QuestionID"].Value = QuestionID;

        try
        {
            DefaultConnection.Open();
            Command.ExecuteNonQuery();
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

    public void DeleteQuestion(int QuestionID)
    {
        SqlCommand DeleteCommand = new SqlCommand("DeleteQuestion", DefaultConnection);
        DeleteCommand.CommandType = CommandType.StoredProcedure;

        DeleteCommand.Parameters.Add("@QuestionID", SqlDbType.Int);
        DeleteCommand.Parameters["@QuestionID"].Value = QuestionID;

        try
        {
            DefaultConnection.Open();
            DeleteCommand.ExecuteNonQuery();
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
}