using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewquestion : System.Web.UI.Page
{
    protected string Question;
    protected string Author;
    protected DateTime PostedTime;
    protected int Views;
    private int QuestionID;

    protected void Page_Load(object sender, EventArgs e)
    {
        QuestionID = int.Parse(Request.QueryString["ID"]);
        QuesDB questionDB = new QuesDB();

        if (!this.IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                if (!(Request.UrlReferrer.Query.Contains(HttpContext.Current.Request.Url.PathAndQuery)
                    || Request.UrlReferrer.AbsoluteUri == Request.Url.AbsoluteUri)) //Do Not Increase View on Refresh or PostBack
                    questionDB.increaseView(QuestionID);
            }
        }

        QuesClass question = questionDB.GetQuestion(QuestionID);

        Question = question.Question;
        Author = question.Author;
        PostedTime = question.PostedTime;
        Views = question.Views;

        List<AnsClass> AnswersList = new List<AnsClass>();
        AnsDB answersDB = new AnsDB();
        AnswersList = answersDB.GetAnswers(QuestionID);
        if (AnswersList.Count == 0)
        {
            AnswersDiv.Visible = false;
        }

        List<AnsClass> SolutionsList = new List<AnsClass>();
        SolutionsList = answersDB.GetSolutions(QuestionID);
        if (SolutionsList.Count == 0)
        {
            SolutionsDiv.Visible = false;
        }


        if (User.Identity.Name == Author)
        {
            Repeater2.DataSource = AnswersList;
            Repeater4.DataSource = SolutionsList;
            answersView.SetActiveView(postedUser);
            solutionsView.SetActiveView(creator);
        }
        else
        {
            Repeater1.DataSource = AnswersList;
            Repeater3.DataSource = SolutionsList;
            answersView.SetActiveView(allUsers);
            solutionsView.SetActiveView(all);
        }

        if (Membership.GetUser() != null)
            AddAnswerView.SetActiveView(LoggedUserView);
        else
            AddAnswerView.SetActiveView(NoUserView);

        ClickHere.NavigateUrl = @"~\Account\Login.aspx?ReturnUrl=" + Page.Request.RawUrl;

        Page.Title = question.Question;
        this.DataBind();

    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int AnswerID = int.Parse(e.CommandArgument.ToString());
        AnsDB solutionDB = new AnsDB();
        solutionDB.SetAsSolution(AnswerID);
        Response.Redirect(Page.Request.RawUrl);

    }

    protected void Repeater4_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int AnswerID = int.Parse(e.CommandArgument.ToString());
        AnsDB solutionDB = new AnsDB();
        solutionDB.RemoveAsSolution(AnswerID);
        Response.Redirect(Page.Request.RawUrl);
    }

    protected void AnswerButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Membership.GetUser() == null)
                Response.Redirect(@"~\Account\Login.aspx?ReturnUrl=" + Page.Request.RawUrl, true);
            else
            {
                AnsDB AnswerDB = new AnsDB();
                AnswerDB.InsertAnswer(new AnsClass(QuestionID, User.Identity.Name, AnswerBox.Text, DateTime.Now));
                Response.Redirect(Page.Request.RawUrl);
            }
        }
    }

}