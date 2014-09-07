using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuesAns
/// </summary>
public class QuesClass
{
    public QuesClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int QuestionID { get; set; }
    public string Question { get; set; }
    public string Author { get; set; }
    public DateTime PostedTime { get; set; }
    public int Views { get; set; }

    public QuesClass(string question, string author, DateTime postedTime)
    {
        Question = question;
        Author = author;
        PostedTime = postedTime;
    }
}