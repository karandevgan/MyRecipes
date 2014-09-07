using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class allquestions : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        questionsList.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable QuestionTable = new QuesDB().GetAllQuestions();

        DataView questionsView = new DataView();
        questionsView.Table = QuestionTable;

        if (Sort.SelectedItem.Value == "Latest")
            questionsView.Sort = "PostedTime DESC";
        else if (Sort.SelectedItem.Value == "Popular")
            questionsView.Sort = "Views DESC";
        else if (Sort.SelectedItem.Value == "Unanswered")
        {
            questionsView.RowFilter = "Answered = 0";
            questionsView.Sort = "PostedTime DESC";
        }
        else if (Sort.SelectedItem.Value == "Mostanswered")
            questionsView.Sort = "TotalAnswers DESC";

        if (questionsView.Count == 0)
            PagerDiv.Visible = false;
        else
            PagerDiv.Visible = true;

        questionsList.DataSource = questionsView;
    }
}