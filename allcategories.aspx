<%@ Page Title="All Categories" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="allcategories.aspx.cs" Inherits="allcategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">All Categories</h2>
    <br />

    <div style="margin: 10px 10px 10px 10px; width: 98%">
        <h4>Select Recipes By Category :</h4>
        <br />

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="ChineseImage" ImageUrl="~\Images\chinese_category.jpg" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="Chinese" />
            <h6 style="text-align: center; margin-top: 0px;">Chinese</h6>
        </div>

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="FrenchImage" ImageUrl="~\Images\french_category.jpg" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="French" />
            <h6 style="text-align: center; margin-top: 0px;">French</h6>
        </div>

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="IndianImage" ImageUrl="~\Images\indian_category.jpg" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="Indian" />
            <h6 style="text-align: center; margin-top: 0px;">Indian</h6>


        </div>

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="GermanImage" ImageUrl="~\Images\german_category.jpg" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="German" />
            <h6 style="text-align: center; margin-top: 0px;">German</h6>


        </div>

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="ItalianImage" ImageUrl="~\Images\italian_category.png" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="Italian" />
            <h6 style="text-align: center; margin-top: 0px;">Italian</h6>

        </div>

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="SpanishImage" ImageUrl="~\Images\spanish_category.jpg" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="Spanish" />
            <h6 style="text-align: center; margin-top: 0px;">Spanish</h6>
        </div>

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="MexicanImage" ImageUrl="~\Images\mexican_category.png" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="Mexican" />
            <h6 style="text-align: center; margin-top: 0px;">Mexican</h6>
        </div>

        <div style="float: left; margin: 10px 5px 10px 5px">
            <asp:ImageButton ID="OtherImage" ImageUrl="~\Images\other_category.jpg" runat="server"
                Width="200" Height="150" OnCommand="Image_Command" CommandArgument="Other" />
            <h6 style="text-align: center; margin-top: 0px;">Other</h6>

        </div>
    </div>
</asp:Content>

