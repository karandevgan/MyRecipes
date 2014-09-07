using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ArticleClass
/// </summary>
public class ArticleClass
{
    public ArticleClass()
    { }

    public int ArticleID { get; set; }
    public string ArticleAuthor { get; set; }
    public string ArticleTitle { get; set; }
    public string ArticleContent { get; set; }
    public DateTime PostedTime { get; set; }

    public ArticleClass(string author, string title, string content)
    {
        ArticleAuthor = author;
        ArticleTitle = title;
        ArticleContent = content;
        PostedTime = DateTime.Now;
    }
}