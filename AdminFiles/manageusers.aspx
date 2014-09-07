<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="manageusers.aspx.cs" Inherits="AdminFiles_manageusers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin: 10px 10px 10px 10px">Manage Users</h2>
    <br />
    <br />
    <div style="margin: 20px 20px 20px 20px">
        <asp:GridView runat="server" ID="UserDataGrid" AllowSorting="True" AllowPaging="true" CellPadding="4" ForeColor="#333333"
            AutoGenerateColumns="False" OnSorting="UserDataGrid_Sorting" Caption="User Details" OnPageIndexChanging="UserDataGrid_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="S. No">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle Width="30px" />
                </asp:TemplateField>

                <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName">
                    <ItemStyle Width="100px" />
                </asp:BoundField>

                <asp:BoundField DataField="Email" HeaderText="E-Mail" SortExpression="Email">
                    <ItemStyle Width="150px" />
                </asp:BoundField>

                <asp:BoundField DataField="LastActivity" HeaderText="Last Activity" SortExpression="LastActivity" DataFormatString="">
                    <ItemStyle Width="150px" />
                </asp:BoundField>

                <asp:BoundField DataField="Approved" HeaderText="Is Allowed?" SortExpression="Approved">
                    <ItemStyle Width="100px" />
                </asp:BoundField>

                <asp:BoundField DataField="UserRole" HeaderText="User Role" SortExpression="UserRole">
                    <ItemStyle Width="100px" />
                </asp:BoundField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="blockuser" runat="server" Text='<%# Membership.GetUser(Eval("UserName").ToString()).IsApproved ? "Block" : "Unblock" %>' OnCommand="blockuser_Command" 
                            CommandArgument='<%# Eval("UserName") %>' CausesValidation="false" OnClientClick="return confirm('Are you sure?');" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="makeadmin" runat="server" Text='<%# Roles.GetRolesForUser(Eval("UserName").ToString()).Contains("Admin") ? "Remove Admin" : "Make Admin" %>' OnCommand="makeadmin_Command" 
                            CommandArgument='<%# Eval("UserName") %>' CausesValidation="false" OnClientClick="return confirm('Are you sure?');" />
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

