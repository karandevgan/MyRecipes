<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <br />
    <br />
    <h2 style="margin-left: 10px">You have been successfully logged out from our site.</h2>
    <br />
    <br />
    <br />
    <h3 style="margin-left: 20px">
        <asp:HyperLink NavigateUrl="~\Account\Login.aspx" runat="server">Click Here</asp:HyperLink> to login again.
    </h3>

</asp:Content>

