<%@ Page Title="Add Article" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="addarticle.aspx.cs" Inherits="Files_addarticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">Write an Article</h2>
    <br />
    <br />

    <div style="margin: 10px 10px 10px 10px">
        <h4>Title of Article: *</h4>
        <asp:TextBox ID="ArticleTitleTxt" runat="server" Width="850px" /><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ArticleTitleTxt"
            CssClass="field-validation-error" ErrorMessage="The title field is required." Display="Dynamic" />
        <br />
        <br />

        <h4>Content of Article: *</h4>
        <asp:TextBox ID="ArticleContentTxt" runat="server" TextMode="MultiLine" Width="850px" Height="500px" /><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ArticleContentTxt"
            CssClass="field-validation-error" ErrorMessage="The content field is required." Display="Dynamic" />
        <br />
        <br />
        <asp:Button ID="UploadArticleBtn" runat="server" Text="Upload" OnClientClick="return confirm('Confirm Upload?');"
            CausesValidation="true" OnClick="UploadArticleBtn_Click" />
    </div>
</asp:Content>
