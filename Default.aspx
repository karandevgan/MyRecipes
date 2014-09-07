<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1>Welcome!</h1>
    <h2>Your Recipes. Your World. Your Website.</h2>
    <br />
    <br />
    <br />
    <div>
        <div style="width: 230px; float: left; margin-left: 10px" id="TopRecipeDiv" runat="server">
            <h3 style="text-align: center; margin: 0px">Recipe of the Week</h3>
            <div class="ImageLink" style="height: 200px; width: 200px">
                <asp:HyperLink ID="TopRecipe" runat="server" Font-Underline="false"
                    NavigateUrl='<%# "~/showrecipe.aspx?RecipeID=" + TopRecipeID %>'
                    Text='Recipe:' CssClass="RecipeHyperlink" ForeColor="White">
                    <div style="height: 35px; margin-top: 0px">
                        <p style="margin: 0px 0px 0px 3px; color: antiquewhite"><%# TopRecipeName %></p>
                    </div>
                    <div style="margin: 2px 2px 0px 2px">
                        <asp:Image runat="server" ID="RecipeImage" Width="570px" Height="550px"
                            ImageUrl='<%# TopRecipeImage %>' BorderWidth="0px" />
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div style="width: 330px; float: left; margin-left: 5%;">
            <h2 style="text-align: center; margin: 0px">Latest Recipes</h2>
            <asp:ListView runat="server" ID="AllRecipeList" GroupItemCount="1">
                <LayoutTemplate>
                    <div>
                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server" />
                    </div>
                </LayoutTemplate>

                <GroupTemplate>
                    <div>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </div>
                </GroupTemplate>

                <ItemTemplate>
                    <div class="ImageLink" style="height: 300px; width: 300px">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="false"
                            NavigateUrl='<%# "~/showrecipe.aspx?RecipeID=" + Eval("RecipeID") %>'
                            Text='Recipe:' CssClass="RecipeHyperlink" ForeColor="White">
                            <div style="height: 35px; margin-top: 0px">
                                <p style="margin: 0px 0px 0px 3px; color: antiquewhite"><%# Eval("RecipeName") %></p>
                            </div>
                            <div style="margin: 2px 2px 0px 2px">
                                <asp:Image runat="server" ID="RecipeImage" Width="570px" Height="550px"
                                    ImageUrl='<%# Eval("ImagePath") %>' BorderWidth="0px" />
                            </div>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <div style="float: none; clear: both; text-align: center">
                <asp:DataPager runat="server" ID="DataPager"
                    PageSize="1" PagedControlID="AllRecipeList">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="5" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>

        <div style="width: 300px; float:left; margin-left: 10px;">
            <h3 style="text-align: center; margin:0px">Latest Articles</h3>
            <br />
            <asp:Repeater runat="server" ID="ArticlesRepeater">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%# "~/showarticle.aspx?ID=" + Eval("ArticleID") %>' runat="server" Text='<%# Eval("ArticleTitle") %>' />
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr />
                </SeparatorTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
