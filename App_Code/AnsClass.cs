using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AnsClass
/// </summary>
public class AnsClass
{
	public AnsClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int AnswerID { get; set; }
    public int QuestionID { get; set; }
    public string Author { get; set; }
    public string Answer { get; set; }
    public DateTime PostedTime { get; set; }

    public AnsClass(int questionID, string author, string answer, DateTime postedTime)
    {
        QuestionID = questionID;
        Author = author;
        Answer = answer;
        PostedTime = postedTime;
    }
}