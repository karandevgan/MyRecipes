using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Files_postquestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void PostButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            QuesDB newQuestionDB = new QuesDB();
            newQuestionDB.InsertQuestion(new QuesClass
                (QuestionTextBox.Text, Membership.GetUser(User.Identity.Name).UserName, DateTime.Now));
        }
    }
}