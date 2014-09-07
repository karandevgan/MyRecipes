using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommentsClass
/// </summary>
public class CommentsClass
{
	public CommentsClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int RecipeID { get; set; }
    public string User { get; set; }
    public string Comment { get; set; }
    public DateTime PostedTime { get; set; }

    public CommentsClass(int recipeid, string user, string comment, DateTime postedtime)
    {
        RecipeID = recipeid;
        User = user;
        Comment = comment;
        PostedTime = PostedTime;
    }
}