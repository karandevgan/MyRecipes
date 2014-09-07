<%@ Page Title="Edit Recipe" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="editrecipe.aspx.cs" Inherits="Files_editrecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">Edit Recipe</h2>

    <div id="EditArea" style="margin: 10px 10px 10px 10px; border: solid 2px; width: 540px; float: left">
        <div style="margin: 10px 10px 10px 10px;">
            <h4>Name</h4>

            <asp:TextBox runat="server" ID="NameTxtBox" Text='<%# RecipeName %>' Width="500px" />
            <asp:RequiredFieldValidator ID="RecipeNameValidator" runat="server" ControlToValidate="NameTxtBox"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />

            <h4>Category</h4>
            <asp:DropDownList ID="CategoryList" runat="server" Width="300px" Font-Size="Large">
                <asp:ListItem Text="Chinese" Value="Chinese" />
                <asp:ListItem Text="French" Value="French" />
                <asp:ListItem Text="Indian" Value="Indian" />
                <asp:ListItem Text="Italian" Value="Italian" />
                <asp:ListItem Text="German" Value="German" />
                <asp:ListItem Text="Mexican" Value="Mexican" />
                <asp:ListItem Text="Spanish" Value="Spanish" />
                <asp:ListItem Text="Other" Value="Other" />
            </asp:DropDownList>

            <h4>Ingredients</h4>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="IngredientsTxt" Text="" Width="500px" Height="100px" />
            <asp:RequiredFieldValidator ID="IngredientsValidator" runat="server" ControlToValidate="IngredientsTxt"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />

            <h4>Directions</h4>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="DirectionsTxt" Text="" Width="500px" Height="100px" />
            <asp:RequiredFieldValidator ID="DirectionsValidator" runat="server" ControlToValidate="DirectionsTxt"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />

            <h4>Preparation Time (in mins)</h4>
            <asp:TextBox runat="server" ID="TimeTxt" TextMode="Number" Text='<%# PreparationTime %>' /><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="TimeTxt"
                CssClass="field-validation-error" ErrorMessage="Incorrect Format" ValidationExpression="[0-9]*" Display="Dynamic" />
            <asp:RequiredFieldValidator ID="PreparationTimeValidator" runat="server" ControlToValidate="TimeTxt"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />

            <br />
            <br />
            <br />
            <asp:Button ID="Update" runat="server" Text="Update" OnClientClick="return confirm('Are You Sure?');" OnClick="Update_Click" />
        </div>
    </div>

    <div id="ImageDiv" style="float: left; margin: 10px 10px 10px 30px">
        <h4>Current Image</h4>
        <br />
        <asp:Image ID="RecipeImage" runat="server" Width="230px" Height="200px"
            BorderStyle="Solid" BorderWidth="2px" BorderColor="#808080" />
        <br />
        <br />
        <h4>Browse File to Change Image</h4>
        <asp:FileUpload ID="PhotoUpload" runat="server" Width="300px" /><br />
        <asp:CustomValidator ID="PhotoUploadValidator" runat="server" CssClass="field-validation-error" ControlToValidate="PhotoUpload"
            ErrorMessage="Incorrect Format or File Size Exceed 100 KB" Display="Dynamic" OnServerValidate="PhotoUploadValidator_ServerValidate" />
    </div>
</asp:Content>
