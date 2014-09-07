using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Files_myquestions : System.Web.UI.Page
{
    protected string user;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        questionsList.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        user = User.Identity.Name;
        DataTable MyQuestionsTable = new QuesDB().GetMyQuestions(user);

        if (MyQuestionsTable.Rows.Count != 0)
        {
            DataView MyQuestions = new DataView();
            MyQuestions.Table = MyQuestionsTable;

            MyQuestionsView.SetActiveView(QuestionsPresent);
            if (SelectionCriteria.SelectedItem.Value == "All")
                MyQuestions.Sort = "PostedTime DESC";
            else if (SelectionCriteria.SelectedItem.Value == "Answered")
            {
                MyQuestions.RowFilter = "Answered = 1";
                MyQuestions.Sort = "PostedTime DESC";
            }
            else if (SelectionCriteria.SelectedItem.Value == "Unanswered")
            {
                MyQuestions.RowFilter = "Answered = 0";
                MyQuestions.Sort = "PostedTime DESC";
            }

            questionsList.DataSource = MyQuestions;
        }
        else
            MyQuestionsView.SetActiveView(NoQuestions);


    }
    
    protected void questionsList_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int questionID = int.Parse(e.CommandArgument.ToString());
        new QuesDB().DeleteQuestion(questionID);

        Response.Redirect(Page.Request.RawUrl);
    }
}