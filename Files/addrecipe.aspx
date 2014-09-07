<%@ Page Title="Add Recipe" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="addrecipe.aspx.cs" Inherits="addrecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left:10px">Upload Your Own Recipe</h2>
    <h4 style="margin-left:15px">Instructions</h4>
    <p class="message-info" style="margin-top:0px">
        Please Write <b>One Ingredient</b> and <b>One Directions</b> in <b>One Line.</b> <br />
        Photo, if any, should have size <b>less than 100 KB.</b>
    </p>
    <ol class="round">
        <li class="one">
            <h5>Give Your Recipe a Name *</h5>
            <asp:TextBox ID="RecipeName" runat="server" Width="500px" />
            <asp:RequiredFieldValidator ID="RecipeNameValidator" runat="server" ControlToValidate="RecipeName"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />

        </li>

        <li class="two">
            <h5>Recipe Category *</h5>
            <asp:DropDownList ID="RecipeCategory" runat="server" Width="300px"
                Font-Size="Large">
                <asp:ListItem Text="Select a Category" Value="Empty" Selected="True" />
                <asp:ListItem Text="Chinese" Value="Chinese" />
                <asp:ListItem Text="French" Value="French" />
                <asp:ListItem Text="Indian" Value="Indian" />
                <asp:ListItem Text="Italian" Value="Italian" />
                <asp:ListItem Text="German" Value="German" />
                <asp:ListItem Text="Mexican" Value="Mexican" />
                <asp:ListItem Text="Spanish" Value="Spanish" />
                <asp:ListItem Text="Other" Value="Other" />
            </asp:DropDownList>
            <asp:CustomValidator runat="server" ID="RecipeCategoryValidator" ErrorMessage="Please Select A Category"
                CssClass="field-validation-error" OnServerValidate="RecipeCategoryValidator_ServerValidate" ControlToValidate="RecipeCategory" />
        </li>
        <li class="three">
            <h5>Ingerdients of recipe *</h5>
            <asp:TextBox ID="Ingredients" runat="server" TextMode="MultiLine" Width="500px" Height="100px" />
            <asp:RequiredFieldValidator ID="IngredientsValidator" runat="server" ControlToValidate="Ingredients"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />
        </li>

        <li class="four">
            <h5>Directions to make recipe *</h5>
            <asp:TextBox ID="Directions" runat="server" TextMode="MultiLine" Width="500px" Height="100px" />
            <asp:RequiredFieldValidator ID="DirectionsValidator" runat="server" ControlToValidate="Directions"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />
        </li>

        <li class="five">
            <h5>Image file for your recipe</h5>
            <asp:FileUpload ID="PhotoUpload" runat="server" Width="510px" />
            <asp:CustomValidator ID="PhotoUploadValidator" runat="server" CssClass="field-validation-error" ControlToValidate="PhotoUpload"
                ErrorMessage="Incorrect Format or File Size Exceed 100 KB" Display="Dynamic" OnServerValidate="PhotoUploadValidator_ServerValidate" />
        </li>

        <li class="six">
            <h5>Preparation Time (in minutes) *</h5>
            <asp:TextBox ID="PreparationTime" runat="server" TextMode="Number" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="PreparationTime"
                CssClass="field-validation-error" ErrorMessage="Incorrect Format" ValidationExpression="[0-9]*" Display="Dynamic" />
            <asp:RequiredFieldValidator ID="PreparationTimeValidator" runat="server" ControlToValidate="PreparationTime"
                CssClass="field-validation-error" ErrorMessage="This field is required." Display="Dynamic" />
        </li>
        <li>
            <asp:Button ID="UploadRecipe" runat="server" Text="Upload" OnClick="UploadRecipe_Click" />
        </li>
    </ol>
</asp:Content>

