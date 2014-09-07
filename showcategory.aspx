<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="showcategory.aspx.cs" Inherits="showcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px"><%# RecipeCategory %></h2>
    <br />
    
    <asp:Label ID="NoRecipeLbl" Visible="false" runat="server" Font-Size="Large" ForeColor="Red">
        There are no recipes available currently in this Category.
    </asp:Label>

    <div style="height: auto" runat="server" id="RecipeDiv">
        <div style="margin-left: 10px; margin-right: 20px; width: auto; float: left">

            <asp:Image ID="GroupImage" Width="350px" Height="300px" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#660033" />
            <br />
            <br />
            <b>Total Recipes : <%# TotalRecipes %></b>
            <br /><br />
            <h4>Sort By - </h4>
            <asp:RadioButtonList ID="Sort" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Table" CellSpacing="10" AutoPostBack="true">
                <asp:ListItem Text="Latest" Value="Latest" />
                <asp:ListItem Text="Popular" Value="Popular" />
                <asp:ListItem Text="Favorites" Value="Favorites" />
                <asp:ListItem Text="Prep Time" Value="PrepTime" />
            </asp:RadioButtonList>

        </div>

        <div style="margin-left: 10px; width: 400px; float: left; border: solid; border-width: 2px; background-color: antiquewhite">
            <h4 style="text-align: center">Recipes : </h4>
            <asp:ListView runat="server" ID="CategoryViewList" GroupItemCount="4">
                <LayoutTemplate>
                    <div style="width: 400px">
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
                        <asp:HyperLink runat="server" Font-Underline="false"
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

            <div style="float: none; clear: both; margin: 30px 0px 0px 35%; width: 50%;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Page :
                <asp:DataPager runat="server" ID="DataPager"
                    PageSize="4" PagedControlID="CategoryViewList">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="3"
                            PreviousPageText="Prev"
                            NextPageText="Next" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>
    </div>
</asp:Content>

