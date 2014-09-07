<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="myrecipes.aspx.cs" Inherits="Files_myrecipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:MultiView ID="MyRecipesView" runat="server">

        <%--This section is when user wants to view his favorite recipes.--%>

        <asp:View runat="server" ID="favorites">
            <h2 style="margin-left: 10px">My Favorites</h2>
            <br />
            <asp:MultiView ID="isFavPresentView" runat="server">

                <%--When there is some fav recipe present.--%>

                <asp:View runat="server" ID="FavPresent">
                    <h3 style="margin-left: 15px">Following are your Favorite Recipes: </h3>
                    <br />
                    <br />
                    <asp:GridView runat="server" ID="RecipesGrid" AllowSorting="True" CellPadding="4" ForeColor="#333333"
                        AutoGenerateColumns="False" OnSorting="RecipesGrid_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="S. No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recipe" SortExpression="RecipeName">
                                <ItemTemplate>
                                    <asp:LinkButton ID="GoToRecipe" runat="server" Text='<%# Eval("RecipeName") %>' PostBackUrl='<%# "~/showrecipe.aspx?RecipeID=" + Eval("RecipeID")  %>' />
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="RecipeCategory" HeaderText="Category" SortExpression="RecipeCategory">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cook" HeaderText="Added By" SortExpression="Cook">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PreparationTime" HeaderText="Time (mins)" SortExpression="PreparationTime">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="removeLink" runat="server" Text="Remove" OnCommand="removeLink_Command" CommandArgument='<%# Eval("RecipeID") %>'
                                        CausesValidation="false" OnClientClick="return confirm('Remove this recipe from your Favorite List?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </asp:View>

                <%--When there is no fav recipe--%>

                <asp:View ID="FavAbsent" runat="server">
                    <h3 style="margin-left: 15px">Sorry, You have currently no recipe as your favorite.</h3>
                    <h5 style="margin-left: 25px">Click on 'Make Favorite' button to make it as your favorite.</h5>
                </asp:View>
            </asp:MultiView>
        </asp:View>

        <%--This section is when user wants to view recipes submitted by him.--%>

        <asp:View runat="server" ID="SubmittedRecipesView">
            <h2 style="margin-left: 10px">My Recipes</h2>
            <br />

            <asp:MultiView ID="isRecipeSubmitted" runat="server">
                <asp:View runat="server" ID="RecipeSubmitted">
                    <h3 style="margin-left: 15px">Following are your own Recipes: </h3>

                    <br />
                    <br />
                    <asp:GridView runat="server" ID="SubmittedRecipesGrid" AllowSorting="True" CellPadding="4" ForeColor="#333333"
                        AutoGenerateColumns="False" OnSorting="SubmittedRecipesGrid_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="S. No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recipe" SortExpression="RecipeName">
                                <ItemTemplate>
                                    <asp:LinkButton ID="GoToRecipe" runat="server" Text='<%# Eval("RecipeName") %>' PostBackUrl='<%# "~/showrecipe.aspx?RecipeID=" + Eval("RecipeID")  %>' />
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="RecipeCategory" HeaderText="Category" SortExpression="RecipeCategory">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DateAdded" HeaderText="Submitted On" DataFormatString="{0:d}" SortExpression="DateAdded">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PreparationTime" HeaderText="Time (mins)" SortExpression="PreparationTime">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Verified" HeaderText="Verified?" SortExpression="Verified">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" OnCommand="deleteLink_Command" CommandArgument='<%# Eval("RecipeID") + "," + Eval("ImagePath") %>' CausesValidation="false"
                                        OnClientClick="return confirm('Are you sure you want to delete this recipe?');" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="editLink" runat="server" Text="Edit" OnCommand="editLink_Command" CommandArgument='<%# Eval("RecipeID") %>' CausesValidation="false"
                                        OnClientClick="return confirm('Are you sure you want to edit this recipe?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </asp:View>

                <asp:View ID="NoRecipeSubmitted" runat="server">
                    <h3 style="margin-left: 15px">Sorry, You have submitted no recipe.</h3>
                    <h5>
                        <asp:HyperLink NavigateUrl="~/Files/addrecipe.aspx" runat="server" Text="Click Here " />
                        to submit one.</h5>
                </asp:View>
            </asp:MultiView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
