using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Files_addarticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UploadArticleBtn_Click(object sender, EventArgs e)
    {
        if (this.Page.IsValid)
        {
            string encodedTitle = HttpUtility.HtmlDecode(ArticleTitleTxt.Text);
            string encodedContent = HttpUtility.HtmlEncode(ArticleContentTxt.Text);

            new ArticleDB().UploadArticle(new ArticleClass(User.Identity.Name, encodedTitle, encodedContent));
            Response.Redirect(@"~\articles.aspx", false);
        }
    }
}