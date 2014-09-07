using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showarticle : System.Web.UI.Page
{
    protected ArticleClass Article;
    protected string decodedContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = int.Parse(Request.QueryString["ID"]);

        if (!this.IsPostBack)
        {
            Article = new ArticleDB().ViewArticle(ID);
            decodedContent = HttpUtility.HtmlDecode(Article.ArticleContent);
            Page.Title = Article.ArticleTitle;
            if (Request.UrlReferrer != null && !new ArticleDB().isAuthor(ID, User.Identity.Name))
            {
                if (!(Request.UrlReferrer.Query.Contains(HttpContext.Current.Request.Url.PathAndQuery)
                    || Request.UrlReferrer.AbsoluteUri == Request.Url.AbsoluteUri))
                    new ArticleDB().IncreaseView(ID);
            }
        }
        this.DataBind();
    }
}