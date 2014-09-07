<%@ Page Title="Manage Recipes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="managerecipes.aspx.cs" Inherits="AdminFiles_managerecipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin: 10px 10px 10px 10px">Manage Recipes</h2>
    <br />
    <br />
    <div style="margin: 20px 20px 20px 20px">
        <asp:GridView runat="server" ID="RecipesGrid" AllowSorting="True" AllowPaging="true" CellPadding="4" ForeColor="#333333"
            AutoGenerateColumns="False" OnSorting="RecipesGrid_Sorting" OnPageIndexChanging="RecipesGrid_PageIndexChanging">
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

                <asp:BoundField DataField="DateAdded" HeaderText="Added On" SortExpression="DateAdded" DataFormatString="{0:d}">
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
                        <asp:LinkButton ID="verifyLink" runat="server" Text='<%# Eval("Verified").ToString() == "False" ? "Verify" : "Unverify" %>' OnCommand="verifyLink_Command" CommandArgument='<%# Eval("RecipeID").ToString() + "," + bool.Parse(Eval("Verified").ToString()) %>'
                            CausesValidation="false" OnClientClick="return confirm('Change verification?');" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" OnCommand="deleteLink_Command" CommandArgument='<%# Eval("RecipeID") + "," + Eval("ImagePath") %>'
                            CausesValidation="false" OnClientClick="return confirm('Delete this recipe?');" />
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
    </div>
</asp:Content>

