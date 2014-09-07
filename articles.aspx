<%@ Page Title="Articles" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="articles.aspx.cs" Inherits="articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">Articles</h2>
    <br />

    <asp:Label ID="NoArticleLbl" Visible="false" runat="server" Font-Size="Large" ForeColor="Red">
        There are no articles available currently.
    </asp:Label>

    <div id="ArticlesDiv" runat="server">
        <div style="margin: 20px; width: auto">
            <h4>Sort By - </h4>
            <asp:RadioButtonList ID="Sort" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Table" CellSpacing="10" AutoPostBack="true">
                <asp:ListItem Text="Latest" Value="Latest" Selected="True" />
                <asp:ListItem Text="Popular" Value="Popular" />
            </asp:RadioButtonList>
        </div>
        <br />
        <br />
        <asp:ListView ID="articlesList" runat="server">
            <ItemTemplate>
                <div style="margin: 10px 10px 10px 10px; width: 90%;">
                    <h3 style="margin: 0px">
                        <asp:HyperLink ID="showArticleLink" NavigateUrl='<%# "~/showarticle.aspx?ID=" + Eval("ArticleID") %>' runat="server">
                        <%# Eval("ArticleTitle") %>
                        </asp:HyperLink>
                    </h3>
                </div>

                <div style="float: left; margin: 0px 0px 0px 15px; width: 90%">
                    <div style="float: left">
                        <p style="font-size: medium; margin: 0px">
                            <b>Posted On:</b> <%# Eval("PostedTime") %>
                        </p>
                    </div>
                    <div style="float: right;">
                        <p style="font-size: medium; margin: 0px">
                            <b>Views:</b> <%# Eval("ArticleViews") %>
                        </p>
                    </div>
                </div>

                <br />
                <div style="float: left; margin: 0px 0px 0px 20px; overflow: hidden; height: 100px; width: 80%;">
                    <p style="font-size: medium"><%# Eval("ArticleContent") %></p>
                </div>

            </ItemTemplate>
            <ItemSeparatorTemplate>
                <div style="float: none; clear: both; margin: 10px">
                    <br />
                    <br />
                    <hr />
                </div>
            </ItemSeparatorTemplate>
        </asp:ListView>

        <br />
        <br />
        <div id="PagerDiv" runat="server" style="float: none; clear: both; margin: 150px 0px 0px 35%; width: 200px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Page :
            <asp:DataPager runat="server" ID="DataPager"
                PageSize="5" PagedControlID="articlesList">
                <Fields>
                    <asp:NumericPagerField ButtonCount="5"
                        PreviousPageText="Prev"
                        NextPageText="Next" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>

