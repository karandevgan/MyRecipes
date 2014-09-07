using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for AnsDB
/// </summary>
public class AnsDB
{
    private string ConnectionString;
    private SqlConnection DefaultConnection;

    public AnsDB()
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DefaultConnection = new SqlConnection(ConnectionString);
    }

    public void InsertAnswer(AnsClass ans)
    {
        SqlCommand InsertCommand = new SqlCommand("AddAnswer", DefaultConnection);
        InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;

        InsertCommand.Parameters.Add("@QuestionID", System.Data.SqlDbType.Int);
        InsertCommand.Parameters["@QuestionID"].Value = ans.QuestionID;

        InsertCommand.Parameters.Add("@Author", System.Data.SqlDbType.NVarChar, 50);
        InsertCommand.Parameters["@Author"].Value = ans.Author;

        InsertCommand.Parameters.Add("@PostedTime", System.Data.SqlDbType.DateTime);
        InsertCommand.Parameters["@PostedTime"].Value = ans.PostedTime;

        InsertCommand.Parameters.Add("@Answer", System.Data.SqlDbType.Text);
        InsertCommand.Parameters["@Answer"].Value = ans.Answer;

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

    public List<AnsClass> GetAnswers(int questionID)
    {
        SqlCommand GetAnswersCommand = new SqlCommand("GetAnswers", DefaultConnection);
        GetAnswersCommand.CommandType = System.Data.CommandType.StoredProcedure;

        GetAnswersCommand.Parameters.Add("@QuestionID", System.Data.SqlDbType.Int);
        GetAnswersCommand.Parameters["@QuestionID"].Value = questionID;

        try
        {
            DefaultConnection.Open();
            SqlDataReader AnswersReader = GetAnswersCommand.ExecuteReader();

            List<AnsClass> AnswersList = new List<AnsClass>();
            while (AnswersReader.Read())
            {
                AnsClass answer = new AnsClass();
                answer.AnswerID = (int)AnswersReader["AnswerID"];
                answer.QuestionID = questionID;
                answer.Author = AnswersReader["Author"].ToString();
                answer.PostedTime = (DateTime)AnswersReader["PostedTime"];
                answer.Answer = AnswersReader["Answer"].ToString();

                AnswersList.Add(answer);
            }

            AnswersReader.Close();
            return AnswersList;
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

    public List<AnsClass> GetSolutions(int questionID)
    {
        SqlCommand GetSolutionsCommand = new SqlCommand("GetSolutions", DefaultConnection);
        GetSolutionsCommand.CommandType = System.Data.CommandType.StoredProcedure;

        GetSolutionsCommand.Parameters.Add("@QuestionID", System.Data.SqlDbType.Int);
        GetSolutionsCommand.Parameters["@QuestionID"].Value = questionID;

        try
        {
            DefaultConnection.Open();
            SqlDataReader SolutionsReader = GetSolutionsCommand.ExecuteReader();

            List<AnsClass> AnswersList = new List<AnsClass>();
            while (SolutionsReader.Read())
            {
                AnsClass answer = new AnsClass();
                answer.AnswerID = (int)SolutionsReader["AnswerID"];
                answer.QuestionID = questionID;
                answer.Author = SolutionsReader["Author"].ToString();
                answer.PostedTime = (DateTime)SolutionsReader["PostedTime"];
                answer.Answer = SolutionsReader["Answer"].ToString();

                AnswersList.Add(answer);
            }

            SolutionsReader.Close();
            return AnswersList;
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

    public void SetAsSolution(int answerID)
    {
        string Command = "UPDATE Answers SET Solution = 1 WHERE AnswerID = @answerID";
        SqlCommand SetAsSolutionCommand = new SqlCommand(Command, DefaultConnection);
        SetAsSolutionCommand.Parameters.AddWithValue("@answerID", answerID);

        try
        {
            DefaultConnection.Open();
            SetAsSolutionCommand.ExecuteNonQuery();
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

    public void RemoveAsSolution(int answerID)
    {
        string Command = "UPDATE Answers SET Solution = 0 WHERE AnswerID = @answerID";
        SqlCommand RemoveAsSolutionCommand = new SqlCommand(Command, DefaultConnection);
        RemoveAsSolutionCommand.Parameters.AddWithValue("@answerID", answerID);
        try
        {
            DefaultConnection.Open();
            RemoveAsSolutionCommand.ExecuteNonQuery();
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