<%@ Page Title="All Recipes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="allrecipes.aspx.cs" Inherits="allrecipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">All Recipes</h2>
    <br />

    <asp:Label ID="NoRecipeLbl" Visible="false" runat="server" Font-Size="Large" ForeColor="Red">
        There are no recipes available currently.
    </asp:Label>

    <div id="RecipesDiv" runat="server">
        <div style="margin: 20px; width: auto">
            <h4>Sort By - </h4>
            <asp:RadioButtonList ID="Sort" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Table" CellSpacing="10" AutoPostBack="true">
                <asp:ListItem Text="Latest" Value="Latest" />
                <asp:ListItem Text="Popular" Value="Popular" />
                <asp:ListItem Text="Favorites" Value="Favorites" />
                <asp:ListItem Text="Prep Time" Value="PrepTime" />
            </asp:RadioButtonList>
        </div>


        <div style="margin: 10px 10px 10px 10px">
            <asp:ListView runat="server" ID="AllRecipeList" GroupItemCount="3">
                <LayoutTemplate>
                    <div style="width: 90%">
                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server" />
                    </div>
                </LayoutTemplate>

                <GroupTemplate>
                    <div>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </div>
                </GroupTemplate>

                <ItemTemplate>
                    <div class="ImageLink">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="false"
                            NavigateUrl='<%# "~/showrecipe.aspx?RecipeID=" + Eval("RecipeID") %>'
                            Text='Recipe:' CssClass="RecipeHyperlink" ForeColor="White">
                            <div style="height: 55px; margin-top: 0px">
                                <p style="margin: 0px 0px 0px 3px; color: antiquewhite"><%# Eval("RecipeName") %></p>
                                <p style="margin: 0px 0px 0px 3px; color: antiquewhite"><%# Eval("PreparationTime") %> min</p>
                            </div>
                            <div style="margin: 2px 2px 0px 2px">
                                <asp:Image runat="server" ID="RecipeImage" Width="170px" Height="150px"
                                    ImageUrl='<%# Eval("ImagePath") %>' BorderWidth="0px" />
                            </div>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div style="float: none; clear: both; margin: 200px 0px 0px 35%; width: 200px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Page :
            <asp:DataPager runat="server" ID="DataPager"
                PageSize="8" PagedControlID="AllRecipeList">
                <Fields>
                    <asp:NumericPagerField ButtonCount="5"
                        PreviousPageText="Prev"
                        NextPageText="Next" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>

</asp:Content>

