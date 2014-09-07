<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="showarticle.aspx.cs" Inherits="showarticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin: 10px 10px 0px 10px"><%# Article.ArticleTitle %></h2>
    <h5 style="margin: 10px 10px 10px 15px">by <%# Article.ArticleAuthor %></h5>
    <hr />
    <div style="width: 90%">
        <p style="margin: 10px 10px 10px 10px;"><%# Article.PostedTime %></p>
        <p style="margin: 10px 10px 10px 10px; white-space: pre-wrap; font-size: medium; text-align:justify"><%# decodedContent %></p>
    </div>
</asp:Content>
