<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="AdminFiles_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin: 10px 10px 10px 10px">Admin Panel</h2>
    <br />
    <h3 style="margin: 10px 10px 10px 30px">Welcome Admin!</h3>
    <br />
    <p style="margin: 10px 10px 10px 10px; font-size:medium">
        Following are your services :
        <br />
        <asp:BulletedList ID="ServicesList" DisplayMode="LinkButton" runat="server" BulletStyle="Numbered"
            OnClick="ServicesList_Click" Font-Size="Medium" >
            <asp:ListItem Text="View Errors" />
            <asp:ListItem Text="Manage Users" />
            <asp:ListItem Text="Manage Recipes" />
            <asp:ListItem Text="Manage Articles" />
            <asp:ListItem Text="Manage Homepage" />
        </asp:BulletedList>
    </p>
</asp:Content>

