<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="managehomepage.aspx.cs" Inherits="AdminFiles_managehomepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin: 10px 10px 10px 10px">Manage Articles</h2>
    <br />
    <br />
    <div style="margin: 20px 20px 20px 20px">
        <h3>Select Editor Choice Recipe:</h3><br />
        <asp:DropDownList runat="server" ID="TopRecipeList" Width="350px" />
        <br /><br />
        <asp:Button Text="Sumbit" runat="server" ID="SubmitButton" OnClick="SubmitButton_Click" />
    </div>
</asp:Content>

