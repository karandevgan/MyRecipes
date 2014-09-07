using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class articles : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        articlesList.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable articlesTable = new ArticleDB().GetAllVerifiedArticles();

        if (articlesTable.Rows.Count > 0)
        {
            DataView articlesView = new DataView();
            articlesView.Table = articlesTable;

            if (Sort.SelectedItem.Value == "Latest")
                articlesView.Sort = "PostedTime DESC";
            else if (Sort.SelectedItem.Value == "Popular")
                articlesView.Sort = "ArticleViews DESC";

            if (articlesView.Count == 0)
                PagerDiv.Visible = false;
            else
                PagerDiv.Visible = true;

            articlesList.DataSource = articlesView;

            NoArticleLbl.Visible = false;
            ArticlesDiv.Visible = true;
        }
        else
        {
            ArticlesDiv.Visible = false;
            NoArticleLbl.Visible = true;
        }
    }
}