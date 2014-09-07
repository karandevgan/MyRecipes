<%@ Page Title="My Questions" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="myquestions.aspx.cs" Inherits="Files_myquestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">Questions Asked By Me</h2>
    <asp:MultiView ID="MyQuestionsView" runat="server">
        <asp:View runat="server" ID="NoQuestions">
            <h3>There are no questions asked by you in our website.</h3>
        </asp:View>
        <asp:View runat="server" ID="QuestionsPresent">
            <p style="margin-left: 10px;">
                <b>Selection Criteria:</b><br />
                <br />
                <asp:DropDownList runat="server" ID="SelectionCriteria" Width="200px" Height="30px">
                    <asp:ListItem Text="All Questions" Value="All" />
                    <asp:ListItem Text="Answered Questions" Value="Answered" />
                    <asp:ListItem Text="Unanswered Questions" Value="Unanswered" />
                </asp:DropDownList><br />
                <asp:Button ID="ShowQuestions" runat="server" Text="Show" />
            </p>

            <asp:ListView ID="questionsList" runat="server" OnItemCommand="questionsList_ItemCommand">
                <ItemTemplate>
                    <div style="float: left; margin-left: 10px; overflow: hidden; height: 80px; width: 80%;">
                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/viewquestion.aspx?ID=" + Eval("QuestionID") %>' runat="server" Text='<%# Eval("Question") %>'
                            Font-Size="Medium" ForeColor="Brown">
                        </asp:HyperLink>
                        <asp:LinkButton Text="Delete" runat="server" CausesValidation="false"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "QuestionID") %>' />
                        <p style="font-size: medium; margin: 0px 0px 0px 15px">
                            Posted On: <%# Eval("PostedTime") %>
                        </p>
                        <hr />
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
