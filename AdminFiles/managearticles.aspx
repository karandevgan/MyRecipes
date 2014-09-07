<%@ Page Title="Manage Articles" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="managearticles.aspx.cs" Inherits="AdminFiles_managearticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin: 10px 10px 10px 10px">Manage Articles</h2>
    <br />
    <br />
    <div style="margin: 20px 20px 20px 20px">
        <asp:GridView runat="server" ID="ArticlesGrid" AllowSorting="True" AllowPaging="true" CellPadding="4" ForeColor="#333333"
            AutoGenerateColumns="False" OnSorting="ArticlesGrid_Sorting" OnPageIndexChanging="ArticlesGrid_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="S. No">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Article" SortExpression="ArticleTitle">
                    <ItemTemplate>
                        <asp:LinkButton ID="GoToArticle" runat="server" Text='<%# Eval("ArticleTitle") %>' PostBackUrl='<%# "~/showarticle.aspx?ID=" + Eval("ArticleID")  %>' />
                    </ItemTemplate>
                    <ItemStyle Width="200px" />
                </asp:TemplateField>

                <asp:BoundField DataField="ArticleAuthor" HeaderText="Author" SortExpression="ArticleAuthor">
                    <ItemStyle Width="150px" />
                </asp:BoundField>

                <asp:BoundField DataField="PostedTime" HeaderText="Added On" SortExpression="PostedTime">
                    <ItemStyle Width="150px" />
                </asp:BoundField>

                <asp:BoundField DataField="ArticleViews" HeaderText="Views" SortExpression="ArticleViews">
                    <ItemStyle Width="50px" />
                </asp:BoundField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="verifyLink" runat="server" Text='<%# Eval("Verified").ToString() == "False" ? "Verify" : "Unverify" %>' OnCommand="verifyLink_Command" CommandArgument='<%# Eval("ArticleID").ToString() + "," + bool.Parse(Eval("Verified").ToString()) %>'
                            CausesValidation="false" OnClientClick="return confirm('Verify this article?');" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="deleteLink" runat="server" Text="Delete" OnCommand="deleteLink_Command" CommandArgument='<%# Eval("ArticleID").ToString() + "," + Eval("ArticleAuthor").ToString() %>'
                            CausesValidation="false" OnClientClick="return confirm('Delete this article?');" />
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
        </asp:GridView>
    </div>
</asp:Content>

