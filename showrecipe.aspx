<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="showrecipe.aspx.cs" Inherits="showrecipe" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px"><%# RecipeTitle %></h2>
    <br />

    <div>
        <div style="float: left; margin-left: 10px">
            <div>
                <asp:Image ID="RecipeImage" runat="server" Width="230px" Height="200px"
                    BorderStyle="Solid" BorderWidth="2px" BorderColor="#808080" />
            </div>

            <div style="float: left; height: auto; width: 230px; background-color: #808080; border-width: 2px; border-style: solid; border-color: #808080">
                <p style="text-align: left; color: white; margin: 0px 0px 0px 10px;">
                    Preparation Time <%# PreparationTime %> Mins
                </p>
            </div>
            <br />
            <br />
            <br />
            <div style="float: left; height: auto; width: 230px; background-color: #808080; border-width: 2px; border-style: solid; border-color: #808080">
                <div style="margin: 0px 0px 0px 10px">
                    <asp:Table runat="server" ForeColor="White">
                        <asp:TableRow>
                            <asp:TableCell Text="Views" />
                            <asp:TableCell>
                                <%# Views %>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="Date Added" />
                            <asp:TableCell>
                                <%# DateAdded.Date.ToShortDateString() %>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="Favorites" />
                            <asp:TableCell>
                                <%# Favorites %>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="Category" />
                            <asp:TableCell>
                                <%# Category %>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div style="float: left; height: auto; width: 230px; margin-left: -2px">
                <asp:ImageButton ID="Favorite_Button" runat="server" ImageUrl="~/Images/add_fav.png"
                    BorderWidth="0" BackColor="Transparent" OnClick="Favorite_Click" CausesValidation="false" />
            </div>
        </div>


        <div style="float: left; width: 70%; border-style: solid; border-width: 1px; border-color: gray; margin-left: 10px; background-color: antiquewhite">
            <div style="margin-left: 10px">
                <h6 style="margin-top: 0px">Ingredients</h6>
                <asp:BulletedList BulletStyle="Numbered" runat="server" ID="IngredientsList">
                </asp:BulletedList>

                <h6>Directions</h6>
                <asp:BulletedList BulletStyle="Numbered" runat="server" ID="DirectionsList">
                </asp:BulletedList>
            </div>
        </div>

        <div style="float: none; clear: both;">
            <br />
            <br />
            <br />
            <h2>Comments:</h2>
            <br />
            <div style="border: 1px solid">
                <asp:Repeater ID="CommentsRepeater" runat="server" Visible="false">
                    <ItemTemplate>
                        <p style="margin: 5px; font-size: medium"><b><%# Eval("UserName") %>:</b></p>
                        <p style="margin: 10px; font-size: medium"><%# Eval("Comment") %></p>
                        <i><%# Eval("PostedTime") %></i>
                        <br />
                        <hr />
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="NoCommentsLabel" runat="server" Text="No Comments Yet." Visible="false" />
                <div id="AddCommentDiv" runat="server" style="margin-left: 10px; margin-top: 40px; width: 50%">
                    <asp:MultiView ID="CommentView" runat="server">
                        <asp:View ID="NoUserView" runat="server">
                            <p class="message-info">
                                You must be logged in to Add Comment. <br />
                                Please <asp:HyperLink ID="ClickHere" runat="server" Text="Click Here" /> to log in.
                            </p>
                        </asp:View>

                        <asp:View ID="LoggedUserView" runat="server">
                            <asp:TextBox ID="CommentBox" Width="100%" TextMode="MultiLine" runat="server" Height="80px" />
                            <asp:RequiredFieldValidator runat="server" ID="CommentValidator" ErrorMessage="This Field is required"
                                ControlToValidate="CommentBox" CssClass="field-validation-error" />
                            <br />
                            <asp:Button runat="server" ID="CommentButton" Text="Post Comment" OnClick="CommentButton_Click" />
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

