<%@ Page Title="Questions" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="allquestions.aspx.cs" Inherits="allquestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2 style="margin-left: 10px">View Questions</h2>
    <br />

    <div style="margin: 20px; width: auto">
        <h4>Sort By - </h4>
        <asp:RadioButtonList ID="Sort" runat="server" RepeatDirection="Horizontal"
            RepeatLayout="Table" CellSpacing="10" AutoPostBack="true">
            <asp:ListItem Text="Latest" Value="Latest" Selected="True" />
            <asp:ListItem Text="Popular" Value="Popular" />
            <asp:ListItem Text="Not Answered" Value="Unanswered" />
            <asp:ListItem Text="Most Answered" Value="Mostanswered" />
        </asp:RadioButtonList>
    </div>
    <br />
    <br />
    <asp:ListView ID="questionsList" runat="server">
        <ItemTemplate>
            <div style="margin: 10px 10px 10px 10px; width: 90%;">
                <div style="float: left; background-color: lightblue; width: 100px; height: 90px">

                    <p style="font-size: larger; margin: 0px 0px 0px 0px; text-align: center">
                        <%# Eval("Views") %><br />
                        <span style="font-size: small">Views</span>

                    <p style="font-size: larger; margin: 0px 0px 0px 0px; text-align: center">
                        <%# Eval("TotalAnswers") %><br />
                        <span style="font-size: small">Answers</span>
                </div>
                <div style="float: left; margin-left: 10px; overflow: hidden; height: 50px; width: 80%;">
                    <asp:HyperLink NavigateUrl='<%# "~/viewquestion.aspx?ID=" + Eval("QuestionID") %>' runat="server" Text='<%# Eval("Question") %>'
                        Font-Size="Medium" ForeColor="Brown">
                    </asp:HyperLink>

                </div>
                <br />
                <div style="float: left; margin-left: 10px; width: 80%">
                    <p style="font-size: medium">
                        Asked By: <%# Eval("Author") %>
                        <span style="margin-left: 30%"></span>Posted On: <%# Eval("PostedTime") %>
                    </p>
                </div>
            </div>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <div style="float: none; clear: both">
                <hr />
            </div>
        </ItemSeparatorTemplate>
    </asp:ListView>
    
    <div id="PagerDiv" style="float: none; clear: both; margin: 200px 0px 0px 25%; width: 200px;" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Page :
            <asp:DataPager runat="server" ID="DataPager"
                PageSize="10" PagedControlID="questionsList">
                <Fields>
                    <asp:NumericPagerField ButtonCount="5"
                        PreviousPageText="Prev"
                        NextPageText="Next" />
                </Fields>
            </asp:DataPager>
    </div>
</asp:Content>

