<%@ Page Title="Post A Question" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="postquestion.aspx.cs" Inherits="Files_postquestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">Post a Question?</h2>
    <br />

    <ul class="message-info">
        <li>Please search for a smiliar question before posting it. It may have already been asked by someone else.</li>
        <li>Kindly post question in a good way and use punctuation marks properly.</li>
        <li>Don't use abusive language and try to post in English only.</li>
    </ul>

    <p style="margin-left: 10px" class="label">
        Enter Your Question :<br />
        <asp:TextBox runat="server" ID="QuestionTextBox" TextMode="MultiLine" Width="50%" Height="50px" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="QuestionTextBox"
            ErrorMessage="This Field Is Required" CssClass="message-error-info" /><br />

        <asp:Button runat="server" Text="Post" ID="PostButton" OnClick="PostButton_Click" />
    </p>

</asp:Content>

